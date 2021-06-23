using Membership.Implementation.Interface;
using System;
using System.IO;

namespace Membership.Implementation.Service
{
    public class FileService : IFile
    {
        public string Read(string path)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentNullException();
            return File.ReadAllText(path);
        }
    }
}