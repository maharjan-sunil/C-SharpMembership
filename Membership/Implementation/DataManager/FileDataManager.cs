using Membership.Implementation.Interface;
using Membership.Implementation.Service;
using System;
using System.Web;

namespace Membership.Implementation.DataManager
{
    public class FileDataManager
    {
        private IFile _file;

        public FileDataManager()
        {
            _file = new FileService();
        }
        public FileDataManager(IFile file = null)
        {
            _file = file ?? new FileService();
        }

        public byte[] GetBytesFromData(string data)
        {
            return _file.GetBytesFromData(data);
        }

        public byte[] GetBytesFromFile(string filePath)
        {
            return _file.GetBytesFromFile(filePath);
        }

        public string ReadFromFile(HttpPostedFileBase file)
        {
            if (file == null)
                throw new ArgumentNullException();
            return _file.ReadFromFile(file);
        }

        public string UploadHttpPostedFileBase(HttpPostedFileBase model, string directory)
        {
            var fileName = _file.UploadHttpPostedFileBase(model, directory);
            return fileName;
        }

        public void UploadFile(byte[] fileByte, string directory, string fileName)
        {
            _file.UploadFileByte(fileByte, directory, fileName);
        }

        //public FileDataManager(IFile file = null)
        //{
        //    _file = file ?? new FileService();
        //}

        //public string ReadFile(string file)
        //{
        //    if (file == null)
        //        throw new ArgumentNullException();
        //    return _file.Read(file);
        //}

        //public List<BaseEntityModel> GetListOfFile(string path)
        //{
        //    return _file.GetFiles(path);
        //}

        //public BaseEntityModel GetFile(string path)
        //{
        //    return _file.FileOnly(path);
        //}



    }
}