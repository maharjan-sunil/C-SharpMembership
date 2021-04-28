using System.Web.Mvc;

namespace Membership.Controllers
{
    public class HomeController : Controller
    {
       [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}