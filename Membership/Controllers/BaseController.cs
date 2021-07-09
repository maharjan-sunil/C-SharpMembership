using System.Web.Mvc;

namespace Membership.Controllers
{
    public class BaseController<DataManager> : Controller
        where DataManager : class, new()
    {

        //new()
        //You can't initialize Generic type object unless you mark
        //it as implementing default constructor using new keyword:

        protected DataManager dataManager;
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                dataManager = new DataManager();
            }
            else
            {
                filterContext.Result = new RedirectResult("~/Account/Login");
            }
        }
    }
}