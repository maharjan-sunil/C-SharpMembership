using Membership.Constant;
using Membership.Custom;
using Membership.Database;
using Membership.Helper;
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
    [Security]
    public class FileController : BaseController<FileManager>
    {
        public ActionResult Index()
        {
            FileModel model = new FileModel();
            return View(model);
        }

        [HttpGet]
        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Upload(FileModel model)
        {
            List<Student> students = new List<Student>();
            if (ModelState.IsValid)
            {
                //read from input stream
                BinaryReader reader = new BinaryReader(model.File.InputStream);

                //convert into byte array
                byte[] binData = reader.ReadBytes((int)model.File.InputStream.Length);

                string fileData = Encoding.Default.GetString(binData);
                for (int count = 1; count < (fileData.Split('\n').Count() - 1); count++)
                {
                    //if you intend to spilt more than one char
                    string dataRow = fileData.Split(new string[] { "\r\n" }, StringSplitOptions.None)[count];

                    if (!string.IsNullOrWhiteSpace(dataRow))
                    {
                        int libraryId;
                        string[] arr = dataRow.Split(';');
                        Int32.TryParse(arr[1], out libraryId);

                        Student student = new Student();
                        student.Name = arr[0];
                        student.LibraryId = !String.IsNullOrEmpty(arr[1]) ? libraryId : 0;
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

        public FileResult Download()
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
                IDownload csvService = new CsvService();
                DownloadManager _downloadManager = new DownloadManager(csvService);
                var file = _downloadManager.GetBytesFromString(str.ToString());
                var fileName = DateTime.Now.ToString("dd-mm-yyyy") + "_Student.csv";

                //if you want to save in some directory in system
                MemoryStream memoryStream = new MemoryStream(file, 0, file.Length);
                memoryStream.Write(file, 0, file.Length);
                memoryStream.Flush();
                memoryStream.Position = 0;

                string directoryPath = System.Web.HttpContext.Current.Server.MapPath("~/SystemFile");
                new LogManager().DirectoryExist(directoryPath);

                //because of white space in fileName i got stuck
                string path = System.Web.HttpContext.Current.Server.MapPath("~/SystemFile/" + fileName);
                FileStream fileStream = new FileStream(path, FileMode.Create);
                memoryStream.CopyTo(fileStream);
                fileStream.Close();

                return File(file, SystemConstant.CsvContentType, fileName);
            }
        }

        public string ReadFile()
        {
            var path = System.Web.HttpContext.Current.Server.MapPath("~/SystemFile/Log.Log");
            return new FileHelper().ReadFile(path);
        }

    }
}