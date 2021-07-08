using Membership.Implementation.Interface;
using Membership.Models;
using System;
using System.Collections.Generic;

namespace Membership.Fake
{
    public class FakeReadService
    {
        public BaseEntityModel FileOnly(string path)
        {
            throw new NotImplementedException();
        }

        //instead of creating fake read service used moq
        public List<BaseEntityModel> GetFiles(string path)
        {
            throw new NotImplementedException();
        }

        public string Read(string path)
        {
            return "file data";
        }
    }
}