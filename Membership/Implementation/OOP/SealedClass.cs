using System;

namespace Membership.Implementation.Class
{
    //prevent from beign inherited
    //but can be instantiated
    sealed class SealedClass
    {
        public void TestSealedClass()
        {
            Console.WriteLine("Testing Sealed Class");
        }
    }
}