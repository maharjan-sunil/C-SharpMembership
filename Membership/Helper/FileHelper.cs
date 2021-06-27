using Membership.Implementation.Interface;
using Membership.Implementation.Service;
using Membership.Models;
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
            return _file.Read(path);
        }

        public List<BaseEntityModel> GetListOfFile(string path)
        {
            return _file.GetFiles(path);
        }
    }
}