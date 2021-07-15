using Membership.Constant;
using Membership.Implementation.DataManager;
using Membership.Implementation.Interface;
using System;
using System.IO;
using System.Text;
using System.Web;

namespace Membership.Implementation.Service
{
    public class FileService : IFile
    {
        private readonly DirectoryManager directoryManager;

        public FileService()
        {
            directoryManager = new DirectoryManager();
        }

        public byte[] GetBytesFromData(string data)
        {
            byte[] file = Encoding.GetEncoding(EncodingConstant.ISO).GetBytes(data);
            return file;
        }
        public byte[] GetBytesFromFile(string filePath)
        {
            string path = HttpContext.Current.Server.MapPath($"~/SystemFile/{filePath}");
            byte[] fileByte = File.ReadAllBytes(path);
            return fileByte;
        }

        public string UploadHttpPostedFileBase(HttpPostedFileBase file, string directory)
        {
            try
            {
                var fileDetail = file.FileName.Split('.');
                var fileName = $"{fileDetail[0]}_{DateTime.Now.ToString("dd-mm-yyyy HH-mm-ss")}.{fileDetail[1]}";

                BinaryReader reader = new BinaryReader(file.InputStream);
                byte[] fileByte = reader.ReadBytes((int)file.InputStream.Length);

                UploadFileByte(fileByte, directory, fileName);
                return fileName;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string ReadFromFile(HttpPostedFileBase file)
        {
            //read from input stream
            BinaryReader reader = new BinaryReader(file.InputStream);

            //convert into byte array
            byte[] binData = reader.ReadBytes((int)file.InputStream.Length);

            string fileData = Encoding.Default.GetString(binData);
            return fileData;
        }

        public void UploadFileByte(byte[] fileByte, string directory, string fileName)
        {
            MemoryStream memoryStream = new MemoryStream(fileByte, 0, fileByte.Length);
            memoryStream.Write(fileByte, 0, fileByte.Length);
            memoryStream.Flush();
            memoryStream.Position = 0;

            string directoryPath = HttpContext.Current.Server.MapPath($"~/SystemFile/{directory}");
            directoryManager.DirectoryExist(directoryPath);

            string path = HttpContext.Current.Server.MapPath($"~/SystemFile/{ directory}/ " + fileName);

            FileStream fileStream = new FileStream(path, FileMode.Create);
            memoryStream.CopyTo(fileStream);
            fileStream.Close();
        }

        //public List<BaseEntityModel> GetFiles(string path)
        //{
        //    if (string.IsNullOrEmpty(path))
        //        return null;

        //    var jsonString = File.ReadAllText(path);
        //    var listOfFile = JsonConvert.DeserializeObject<List<BaseEntityModel>>(jsonString);
        //    return listOfFile;
        //}

        //public string Read(string path)
        //{
        //    return File.ReadAllText(path);
        //}

        //public BaseEntityModel FileOnly(string path)
        //{
        //    if (!string.IsNullOrEmpty(path))
        //    {
        //        return new BaseEntityModel { };
        //    }
        //    throw new ArgumentNullException();
        //}


    }
}