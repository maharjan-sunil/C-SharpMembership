using System.Linq;
using System.Web.Mvc;

namespace Membership.Custom
{
    public class Security : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            var context = filterContext.HttpContext.User;
            string[] roles = System.Web.Security.Roles.GetRolesForUser(context.Identity.Name);
            if (roles.Contains("Admin"))
            {
            }
            else
            {
                HandleUnauthorizedRequest(filterContext);
            }

        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectResult("~/Home/AccessDenied");
        }
    }
}