using Membership.Implementation.Interface;
using Membership.Implementation.Service;
using Membership.Models;
using System.Linq;

namespace Membership.Implementation.DataManager
{
    public class OrderDataManager
    {
        private readonly IOrder _order;
        public OrderDataManager(IOrder order = null)
        {
            _order = order ?? new OrderService();
        }

        public string GetOverLappingOrder(Order order)
        {
            if (!order.Status)
                return string.Empty;

            var list = _order.GetList();
            var overLappingOrder = list.Where(l => l.Id != order.Id && l.Status);
            if (overLappingOrder == null)
                return string.Empty;

            return overLappingOrder.FirstOrDefault().ReferenceId;
        }

    }
}