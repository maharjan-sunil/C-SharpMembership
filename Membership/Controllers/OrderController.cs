using Membership.Implementation.Interface;
using System.Web.Mvc;

namespace Membership.Controllers
{
    public class OrderController : Controller, IOrder
    {
        public int OrderId
        {
            get => throw new System.NotImplementedException();
            set => throw new System.NotImplementedException();
        }

        // GET: Order
        public ActionResult Index()
        {
            return View();
        }

        public decimal TotalPrice()
        {
            throw new System.NotImplementedException();
        }
    }
}