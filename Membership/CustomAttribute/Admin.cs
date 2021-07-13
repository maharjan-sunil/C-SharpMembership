using System.Linq;
using System.Web.Mvc;

namespace Membership.CustomAttribute
{
    public class Admin : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var context = filterContext.HttpContext.User;
            if (context.Identity.IsAuthenticated)
            {
                string[] roles = System.Web.Security.Roles.GetRolesForUser(context.Identity.Name);
                if (roles.Contains("Admin"))
                {
                }
                else
                {
                    HandleUnauthorizedRequest(filterContext);
                }
            }
            else
            {
                filterContext.Result = new RedirectResult("~/Account/Login");
            }

        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectResult("~/Home/AccessDenied");
        }
    }
}