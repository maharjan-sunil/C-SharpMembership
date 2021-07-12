using Membership.CustomAttribute;
using Membership.Implementation.DataManager;
using Membership.Implementation.Interface;
using Membership.Models;
using System.Web.Mvc;

namespace Membership.Controllers
{
    [Admin]
    public class MemberController : Controller, IController<MemberModel>
    {
        private IDataManager<MemberModel> _repository;

        public MemberController()
        {
            _repository = new MemberDataManager();
        }

        public bool Create(MemberModel model)
        {
            var result = _repository.Add(model);
            return result;
        }

        public bool Delete(int id)
        {
            var result = _repository.Delete(id);
           return result;
        }

        public bool Edit(MemberModel model)
        {
            var result = _repository.Edit(model);
            return result;
        }

        public MemberModel GetDetail(int id)
        {
            var model = _repository.GetDetail(id);
            return model;
        }

        public ActionResult Index()
        {
            var listOfMember = _repository.GetList();
            return View(listOfMember);
        }

        //public ActionResult Index(string query)
        //{
        //    throw new System.NotImplementedException();
        //}
    }
}