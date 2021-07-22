using Membership.CustomAttribute;
using Membership.Implementation.DataManager;
using Membership.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;

namespace Membership.Controllers
{
    [SuperAdminAuthorize]
    public class LogController : BaseController<LogDataManager>
    {
        // GET: Log
        public ActionResult Index()
        {
            //demo of protected
            //   dataManager.Log(new LoginModel { Username = "Sunil" });
            List<LoginModel> list = new List<LoginModel>();
              //LoginLogModel model = new LoginLogModel();
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
}