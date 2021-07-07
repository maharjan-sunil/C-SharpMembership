using Membership.Implementation.DataManager;
using Membership.Models;

namespace Membership.Controllers
{
    public class OrderController : BaseController<OrderDataManager>
    {
        public string OverLappingOrderExist(Order order)
        {
            var overLappingReferenceId = dataManager.GetOverLappingOrder(order);
            return overLappingReferenceId;
        }
    }
}