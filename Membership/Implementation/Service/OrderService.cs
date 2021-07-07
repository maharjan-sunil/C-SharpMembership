using Membership.Implementation.Interface;
using Membership.Models;
using System;
using System.Collections.Generic;

namespace Membership.Implementation.Service
{
    public class OrderService : IOrder
    {
        public int OrderId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int GetOrderId(object obj)
        {
            throw new NotImplementedException();
        }

        public decimal TotalPrice()
        {
            throw new NotImplementedException();
        }

        List<Order> IOrder.GetList()
        {
            return new List<Order>
            {
                new Order
                {
                    Id=2,
                    Status = true,
                    ReferenceId = "10"
                },
                new Order
                {
                    Id=3,
                    Status = true,
                    ReferenceId = "100"
                }
            };
        }
    }
}