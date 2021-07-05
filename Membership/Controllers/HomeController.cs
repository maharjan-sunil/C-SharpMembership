using System.Web.Mvc;

namespace Membership.Controllers
{
    public class HomeController : Controller
    {
        // [Authorize]
        public ActionResult Index()
        {
            //int i = 2;
            //BaseClass b = new BaseClass();
            //string result = b.Function();
            //DerivedClass d = new DerivedClass();
            //string result_1 = d.Function();
            //BaseClass b1 = new DerivedClass();
            //string result_2 = b1.Function();
            //int countryId = (int)Country.DK;

            ////to retrieve key from enum
            //string EnumValue = Enum.GetName(typeof(Country),i);
            return View();
        }

        public ActionResult AccessDenied()
        {
            return View();
        }
    }
}