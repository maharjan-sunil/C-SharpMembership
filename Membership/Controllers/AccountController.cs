using Membership.Helper;
using Membership.Implementation.DataManager;
using Membership.Implementation.Interface;
using Membership.Models;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace Membership.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILog _log;

        public AccountController()
        {
            _log = new LogDataManager();
        }

        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            LoginModel model = new LoginModel();
            return View(model);
        }

        [HttpPost]
        [ValidateGoogleCaptchaAttribute]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (System.Web.Security.Membership.ValidateUser(model.Username, model.Password))
                {
                    model.Login = "Success";
                    _log.Log(model);
                    FormsAuthentication.SetAuthCookie(model.Username, false);
                    return RedirectToLocal(returnUrl);
                }
                model.Login = "Failure";
                _log.Log(model);
            }
            return View(model);
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        [HttpGet]
        public ActionResult Register()
        {
            RegisterModel model = new RegisterModel();
            model.ListOfRoles = Roles.GetAllRoles().ToList();
            return View(model);
        }

        [HttpPost]
        [ValidateGoogleCaptchaAttribute]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                MembershipCreateStatus createStatus;
                MembershipUser newUser = System.Web.Security.Membership.Provider.CreateUser(model.Username, model.Password, null, null, null, true, null, out createStatus);
                if (createStatus == MembershipCreateStatus.Success)
                {
                    CreateRoles();
                    Roles.AddUserToRole(newUser.UserName, model.RoleId);
                    return RedirectToAction("Login");
                }
            }
            model.ListOfRoles = Roles.GetAllRoles().ToList();
            return View(model);
        }

        private void CreateRoles()
        {
            if (!Roles.RoleExists("SuperAdmin"))
                Roles.CreateRole("SuperAdmin");

            if (!Roles.RoleExists("Admin"))
                Roles.CreateRole("Admin");

            if (!Roles.RoleExists("Staff"))
                Roles.CreateRole("Staff");

        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Member");
        }
    }
}