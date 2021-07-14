using Membership.CustomAttribute;
using Membership.Implementation.DataManager;
using Membership.Implementation.Interface;
using Membership.Models;
using System.Web.Mvc;

namespace Membership.Controllers
{
    [Authorize]
    public class MemberController : Controller, IController<MemberModel>
    {
        private IDataManager<MemberModel> _repository;

        public MemberController()
        {
            _repository = new MemberDataManager();
        }

        [HttpGet]
        public ActionResult Index()
        {
            var listOfMember = _repository.GetList();
            return View(listOfMember);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(MemberModel model)
        {
            var listOfMember = _repository.GetList(model);
            return View(listOfMember);
        }

        [HttpGet]
        [AdminAuthorize]
        public ActionResult Create()
        {
            var model = new MemberModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AdminAuthorize]
        public ActionResult Create(MemberModel model)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        [AdminAuthorize]
        public ActionResult Edit(int id)
        {
            var model = _repository.GetDetail(id);
            return View(model);
        }

        [HttpPost]
        [AdminAuthorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MemberModel model)
        {
            if (ModelState.IsValid)
            {
                _repository.Edit(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [AdminAuthorize]
        public bool Delete(int id)
        {
            var result = _repository.Delete(id);
           return result;
        }

        public JsonResult GetDetail(int id)
        {
            var model = _repository.GetDetail(id);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

     
    }
}