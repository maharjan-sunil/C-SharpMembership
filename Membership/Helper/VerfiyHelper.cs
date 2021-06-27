using System;

namespace Membership.Helper
{
    public class VerfiyHelper
    {
        private readonly IOrder _order;
        
        public VerfiyHelper(IOrder order)
        {
            _order = order;
        }

        public int GetOrder(Order order)
        {
           return _order.GetOrderId(order);
        }
    }

    public class Order
    {
        public bool OrderId { get; set; }
    }

    public interface IOrder
    {
        int GetOrderId(Object obj);
    }
}