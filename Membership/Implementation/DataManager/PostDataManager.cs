using Membership.Implementation.Interface;
using Membership.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Membership.Implementation.DataManager
{
    public class PostDataManager : IBase<PostModel>
    {
        private readonly HttpClient client;
        public PostDataManager()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(Constant.BaseUrl.Url.BaseUrl);
        }
        public async Task<bool> Add()
        {
            var model = new PostModel
            {
                id = 100,
                title = "New Post",
                body = "Post Body",
                userId = 2
            };

            // PostAsJsonAsync supported by WebClient API 
            HttpResponseMessage response = client.PostAsJsonAsync<PostModel>("posts", model).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> Delete()
        {
            string id = "1";
            HttpResponseMessage response = await client.DeleteAsync("posts/" + id).ConfigureAwait(false);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }

        public Task<PostModel> Get()
        {
            throw new NotImplementedException();
        }

        public async Task<List<PostModel>> GetList()
        {
            var list = new List<PostModel>();
            try
            {
                //headers
                //client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("posts").ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    list = JsonConvert.DeserializeObject<List<PostModel>>(jsonString);
                }
            }
            catch (Exception ex)
            {
            }
            return list;
        }

        public async Task<bool> Update()
        {
            var model = new PostModel
            {
                id = 100,
                title = "New Post",
                body = "Post Body",
                userId = 2
            };

            HttpResponseMessage response = await client.PutAsJsonAsync<PostModel>("posts", model).ConfigureAwait(false);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }
    }
}