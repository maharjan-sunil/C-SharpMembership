using Membership.Implementation.Class;

namespace Membership.Models.DataManager
{
    public class AbstractTest : AbstractClass
    {
        //cannot create instance of abstract class
        // AbstractClass obj = new AbstractClass();

        public decimal GetTotalPrice(decimal price)
        {
            return CheckOut(price);
        }

        //must override abstract method defined in abstrct class
        public override decimal CheckOut(decimal total)
        {
            return total;
        }
    }
}