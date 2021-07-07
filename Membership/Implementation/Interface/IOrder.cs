using Membership.Models;
using System;
using System.Collections.Generic;

namespace Membership.Implementation.Interface
{
    public interface IOrder
    {
        //interface cannot contain instance field
        //int total = 0;

        //by default all method defined in interface are abtract
        //which means cannot have non-abstract method
        decimal TotalPrice();
        int GetOrderId(Object obj);

        //cannot have variable except fot that can have field
        //All fields in interface are public static final, i.e. they are constants.
        //int OrderId { get; set; }
        List<Order> GetList();
        void InteractionTest(Object order);
        
    }
}
