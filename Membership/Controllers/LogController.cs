using Membership.CustomAttribute;
using Membership.Implementation.DataManager;
using Membership.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;

namespace Membership.Controllers
{
    //[SuperAdminAuthorize]
    public class LogController : BaseController<LogDataManager>
    {
        // GET: Log
        public ActionResult Index()
        {
            var source = new Log
            {
                Id = 1,
                Name = "Harish"
            };

            DomainModel.Log destination = AutoMapper.Mapper.Map<DomainModel.Log>(source);
            List<LoginModel> list = new List<LoginModel>();
            string logPath = System.Web.HttpContext.Current.Server.MapPath("~/SystemFile/Log.Log");
            using (StreamReader stream = new StreamReader(logPath))
            {
                var log = stream.ReadToEnd();
                list = JsonConvert.DeserializeObject<List<LoginModel>>(log);
            }
            return View(list);
        }

        public void Std_Lib()
        {
            dataManager.GetStdLibFromSP();
        }
    }

    public class Log
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

}