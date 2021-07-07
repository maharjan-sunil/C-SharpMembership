using Membership.Implementation.Interface;
using Membership.Implementation.Service;
using Membership.Models;
using System;
using System.Collections.Generic;

namespace Membership.Implementation.DataManager
{
    public class FileDataManager
    {
        private IFile _file;

        public FileDataManager()
        {

        }

        public FileDataManager(IFile file = null)
        {
            _file = file ?? new FileService();
        }

        //implemented via constructor param injection
        public string ReadFile(string path)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentNullException();
            return _file.Read(path);
        }

        public List<BaseEntityModel> GetListOfFile(string path)
        {
            return _file.GetFiles(path);
        }

        public BaseEntityModel GetFile(string path)
        {
            return _file.FileOnly(path);
        }

    }
}