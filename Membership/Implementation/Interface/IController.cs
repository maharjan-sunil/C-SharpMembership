using System.Web.Mvc;

namespace Membership.Implementation.Interface
{
    interface IController<Model>
        where Model : class
    {
        ActionResult Index();
        ActionResult Index(Model model);
        ActionResult Create();
        ActionResult Create(Model model);
        ActionResult Edit(int id);
        ActionResult Edit(Model model);
        JsonResult GetDetail(int id);
        bool Delete(int id);
     
    }
}
