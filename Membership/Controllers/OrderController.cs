using Membership.Implementation.DataManager;
using Membership.Models;
using System.Web.Mvc;

namespace Membership.Controllers
{
    public class OrderController : Controller
    {
        //public int OrderId
        //{
        //    get => throw new System.NotImplementedException();
        //    set => throw new System.NotImplementedException();
        //}

        //// GET: Order
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //public decimal TotalPrice()
        //{
        //    throw new System.NotImplementedException();
        //}

        public string OverLappingOrderExist(Order order)
        {
            //Order order = new Order
            //{
            //    Id = 1,
            //    Status = true,
            //    ReferenceId = "100"
            //};
            var overLappingReferenceId = new OrderDataManager().GetOverLappingOrder(order);
            return overLappingReferenceId;
        }
    }
}