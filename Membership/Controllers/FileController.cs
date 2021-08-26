using Membership.Constant;
using Membership.CustomAttribute;
using Membership.Database;
using Membership.Implementation.DataManager;
using Membership.Implementation.Interface;
using Membership.Implementation.Service;
using Membership.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Membership.Controllers
{
    [AdminAuthorize]
    public class FileController : BaseController<FileDataManager>
    {
        private readonly DirectoryManager directoryManager;
        private const string Directory = "File";

        public FileController()
        {
            directoryManager = new DirectoryManager();
        }
        public ActionResult Index()
        {
            FileModel model = new FileModel();
            return View(model);
        }

        [HttpGet]
        public ActionResult Upload()
        {
            var model = new FileModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Upload(FileModel model)
        {
            List<Student> students = new List<Student>();
            if (ModelState.IsValid)
            {
                string fileData = dataManager.ReadFromFile(model.CSVFile);
                for (int count = 1; count < (fileData.Split('\n').Count() - 1); count++)
                {
                    //if you intend to spilt more than one char
                    string dataRow = fileData.Split(new string[] { "\r\n" }, StringSplitOptions.None)[count];

                    if (!string.IsNullOrWhiteSpace(dataRow))
                    {
                        int libraryId;
                        string[] arr = dataRow.Split(';');
                        Int32.TryParse(arr[2], out libraryId);

                        Student student = new Student();
                        student.Name = arr[1];
                        student.LibraryId = !String.IsNullOrEmpty(arr[2]) ? libraryId : 0;
                        students.Add(student);
                    }
                }
                using (var db = new MembershipEntities())
                {
                    foreach (var std in students)
                    {
                        db.Students.Add(std);
                        db.SaveChanges();
                    }
                }
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public FileResult Downloads()
        {
            using (var db = new MembershipEntities())
            {
                var listOfStudent = db.Students.ToList();
                StringBuilder str = new StringBuilder();
                str.Append("Id");
                str.Append(SystemConstant.CsvSeparataor);
                str.Append("Name");
                str.Append(SystemConstant.CsvSeparataor);
                str.Append("LibraryId");
                str.Append(SystemConstant.CsvSeparataor);
                str.AppendLine();

                foreach (var student in listOfStudent)
                {
                    str.Append(student.StudentId);
                    str.Append(SystemConstant.CsvSeparataor);
                    str.Append(student.Name);
                    str.Append(SystemConstant.CsvSeparataor);
                    str.Append(student.LibraryId);
                    str.Append(SystemConstant.CsvSeparataor);
                    str.AppendLine();
                }

                //use "IDownload" interface to inject CsvService class objects in DownloadManager class constructor
                IFile csvService = new FileService();
                FileDataManager _fileManager = new FileDataManager(csvService);
                var fileByte = _fileManager.GetBytesFromData(str.ToString());
                var fileName = DateTime.Now.ToString("dd-mm-yyyy") + "_Student.csv";

                dataManager.UploadFile(fileByte,Directory,fileName);

                return File(fileByte, SystemConstant.CsvContentType, fileName);
            }
        }

        //public string ReadFile()
        //{
        //    var path = System.Web.HttpContext.Current.Server.MapPath("~/SystemFile/Log.Log");
        //    return dataManager.ReadFile(path);
        //}

        //public List<BaseEntityModel> ReadFiles()
        //{
        //    var path = System.Web.HttpContext.Current.Server.MapPath("~/SystemFile/File.txt");
        //    return dataManager.GetListOfFile(path);
        //}



    }
}