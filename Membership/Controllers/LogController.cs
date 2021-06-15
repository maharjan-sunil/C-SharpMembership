using Membership.Models;
using System.IO;
using System.Web.Mvc;

namespace Membership.Controllers
{
    public class LogController : Controller
    {
        // GET: Log
        public ActionResult Index()
        {
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