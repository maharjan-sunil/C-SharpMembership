namespace Membership.Implementation.Interface
{
    public interface IOrder
    {
        //interface cannot contain instance field
        //int total = 0;

        //by default all method defined in interface are abtract
        //which means cannot have non-abstract method
        decimal TotalPrice();

        //cannot have variable except fot that can have field
        //All fields in interface are public static final, i.e. they are constants.
        int OrderId { get; set; }
    }
}
