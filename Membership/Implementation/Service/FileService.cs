using Membership.Implementation.Interface;
using Membership.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Membership.Implementation.Service
{
    public class FileService : IFile
    {
        public List<BaseEntityModel> GetFiles(string path)
        {
            if (string.IsNullOrEmpty(path))
                return null;

            var jsonString = File.ReadAllText(path);
            var listOfFile = JsonConvert.DeserializeObject<List<BaseEntityModel>>(jsonString);
            return listOfFile;
        }

        public string Read(string path)
        {
            return File.ReadAllText(path);
        }

        public BaseEntityModel FileOnly(string path)
        {
            if (!string.IsNullOrEmpty(path))
            {
                return new BaseEntityModel { };
            }
            throw new ArgumentNullException();
        }
    }
}