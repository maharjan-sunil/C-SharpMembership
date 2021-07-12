using System.Web.Mvc;

namespace Membership.Implementation.Interface
{
    interface IController<Model>
        where Model : class
    {
        ActionResult Index();
        JsonResult GetDetail(int id);
        //ActionResult Index(string query);
        bool Create(Model model);
        bool Delete(int id);
        bool Edit(Model model);
    }
}
