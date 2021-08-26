using System.Web.Mvc;

namespace Membership.Implementation.Interface
{
    interface IController<Model,ViewModel>
        where Model : class
        where ViewModel: class
    {
        ActionResult Index();
        ActionResult Index(ViewModel model);
        ActionResult Create();
        ActionResult Create(Model model);
        ActionResult Edit(int id);
        ActionResult Edit(Model model);
        JsonResult GetDetail(int id);
        bool Delete(int id);
     
    }
}
