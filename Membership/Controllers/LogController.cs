using Membership.Implementation.DataManager;
using Membership.Models;
using System.IO;
using System.Web.Mvc;

namespace Membership.Controllers
{
    public class LogController : BaseController<LogDataManager>
    {
        // GET: Log
        public ActionResult Index()
        {
            //demo of protected
            dataManager.LogLogin(new LoginModel { Username = "Sunil" });

            LoginLogModel model = new LoginLogModel();
            string logPath = System.Web.HttpContext.Current.Server.MapPath("~/SystemFile/Log.Log");
            using (StreamReader stream = new StreamReader(logPath))
            {
                model.Log = stream.ReadToEnd();
            }
            return View(model);
        }
    }
}