using Membership.CustomAttribute;
using System.Web.Mvc;

namespace Membership.Controllers
{
    [Authorize]
    public class MemberController : Controller
    {
        // GET: Member
        public ActionResult Index()
        {
            return View();
        }
    }
}