using Membership.Implementation.DataManager;
using System.Web.Mvc;

namespace Membership.Controllers
{
    public class PostController : BaseController<PostDataManager>
    {
        public ActionResult Index()
        {
            var list = dataManager.GetList();
            return View(list);
        }

        public bool Get()
        {
            var result = dataManager.Get().Result;
            return false;
        }

        public bool Add()
        {
            var result = dataManager.Add().Result;
            return result;
        }

        public bool Update()
        {
            var result = dataManager.Update().Result;
            return result;
        }

        public bool Delete()
        {
            var result = dataManager.Delete().Result;
            return result;
        }


    }
}