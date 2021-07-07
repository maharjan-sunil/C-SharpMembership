using Membership.Implementation.Interface;
using Membership.Implementation.Service;
using Membership.Models;
using System;
using System.Collections.Generic;

namespace Membership.Helper
{
    public class FileHelper
    {
        private IFile _file;

        public FileHelper(IFile file = null)
        {
            _file = file ?? new FileService();
        }

        //implemented via constructor param injection
        public string ReadFile(string path)
        {
            try
            {
                var result = _file.Read(path);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
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