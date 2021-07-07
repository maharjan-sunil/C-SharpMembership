namespace Membership.Implementation.Class
{
    public class BaseClass
    {
        // if you dont use virtual then it wont override the parent 
        public virtual string Function()
        {
            return "Base Class";
        }
    }
}