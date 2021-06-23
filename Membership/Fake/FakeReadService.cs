using Membership.Implementation.Interface;
using System;

namespace Membership.Fake
{
    public class FakeReadService : IFile
    {
        public string Read(string path)
        {
            if (!String.IsNullOrEmpty(path))
            {
                return "file data";
            }
            throw new ArgumentNullException();
        }
    }
}