using Membership.Implementation.Interface;
using Membership.Implementation.Service;

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
    }
}