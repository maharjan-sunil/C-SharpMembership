using Membership.Implementation.Interface;
using System.Web.Mvc;

namespace Membership.Controllers
{
    public class OrderController : Controller, IOrder
    {
        private int Id;

        // Please do check for this Interface field use
        public int OrderId
        {
            get => Id;
            set =>
                Id = 1;

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