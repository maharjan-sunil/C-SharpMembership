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

            //var list = new List<BaseEntityModel>
            //{
            //    new BaseEntityModel
            //    {
            //        Id=1,
            //        Name="file1.txt"
            //    },
            //     new BaseEntityModel
            //    {
            //        Id=2,
            //        Name="file2.txt"
            //    }
            //};
            //var fileText = JsonConvert.SerializeObject(list);

            //File.WriteAllText(path,fileText);

            var jsonString = File.ReadAllText(path);
            var listOfFile = JsonConvert.DeserializeObject<List<BaseEntityModel>>(jsonString);
            return listOfFile;
        }

        public string Read(string path)
        {
            if (string.IsNullOrEmpty(path))
                return "";
            return File.ReadAllText(path);
        }

        public BaseEntityModel FileOnly(string path)
        {
            if (string.IsNullOrEmpty(path))
            {

            }
            return new BaseEntityModel { };
        }
    }
}