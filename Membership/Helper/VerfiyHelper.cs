﻿using Membership.Implementation.Interface;
using Membership.Models;

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

}