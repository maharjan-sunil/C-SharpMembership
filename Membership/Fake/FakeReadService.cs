using Membership.Implementation.Interface;
using Membership.Models;
using System;
using System.Collections.Generic;

namespace Membership.Fake
{
    public class FakeReadService
    {
        //instead of creating fake read service used moq
        public List<BaseEntityModel> GetFiles(string path)
        {
            throw new NotImplementedException();
        }

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