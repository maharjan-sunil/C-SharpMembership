using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNetConcept.Implementation
{
    class LongTask
    {
        public async Task<List<UserModel>> GetList()
        {
            var list = new List<UserModel>();

            for (int i = 1; i <= 3; i++)
            {
                var model = new UserModel();
                model.Id = i;
                model.UserName = $"Test_{i}";
                list.Add(model);
            }
            return list;
        }
    }
    public class UserModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
    }
}
