using Membership.Implementation.Class;

namespace Membership.Models.DataManager
{
    public class SealedTest
    {
        private readonly SealedClass lockObj;
        public SealedTest()
        {
            //can be instantiated
            lockObj = new SealedClass();
        }

        public void AccessSealedClass()
        {
            lockObj.TestSealedClass();
        }



    }
}