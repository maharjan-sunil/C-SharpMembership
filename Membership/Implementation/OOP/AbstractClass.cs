namespace Membership.Implementation.Class
{
    //abstract class cannot be instantiated but can be inherited
    public abstract class AbstractClass
    {
        //abstract method doesn't have body definition
        public abstract decimal CheckOut(decimal total);
        //abstract class can contain non abstract method
        public decimal Discount(decimal total, decimal discount)
        {
            return total - (discount / 100) * total;
        }
    }
} 