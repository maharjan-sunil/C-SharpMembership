using Membership.Constant;
using Membership.CustomAttribute;
using Membership.Implementation.DataManager;
using Membership.Implementation.Interface;
using Membership.Models;
using System;
using System.Web.Mvc;

namespace Membership.Controllers
{
    [Authorize]
    public class MemberController : Controller, IController<MemberModel,MemberViewNodel>
    {
        private IDataManager<MemberModel, MemberViewNodel> _repository;
        private const string Directory = "Member";
        private readonly FileDataManager fileDataManager;

        public MemberController()
        {
            _repository = new MemberDataManager();
            fileDataManager = new FileDataManager();
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = new MemberViewNodel();
            model = _repository.GetList(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(MemberViewNodel model)
        {
            model = _repository.GetList(model);
            return View(model);
        }

        [HttpGet]
        [AdminAuthorize]
        public ActionResult Create()
        {
            var model = new MemberModel();
            model.IsFileRequired = true;
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
            model.IsFileRequired = false;
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

        public FileResult Download(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentNullException();
            var fileByte = fileDataManager.GetBytesFromFile($"{Directory}/{fileName}");
            return File(fileByte, SystemConstant.CsvContentType, fileName);

        }
    }
}