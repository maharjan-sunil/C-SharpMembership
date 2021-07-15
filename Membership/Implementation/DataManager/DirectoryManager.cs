using System.IO;

namespace Membership.Implementation.DataManager
{
    public class DirectoryManager
    {
        public void DirectoryExist(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);
        }
    }
}