using Membership.Helper;
using Moq;
using NUnit.Framework;

namespace MembershipTest
{
    [TestFixture]
    public class VerifyHelperTests
    {
        [Test]
        public void GetOrder_ShouldHave_SameOrderObjectPassedInParamater()
        {
            var VerifyMock = new Mock<IOrder>();
            var Verify = new VerfiyHelper(VerifyMock.Object);

            var Order = new Order();
            Verify.GetOrder(Order);

            //verifies that the same object have been used
            //interaction testing
            VerifyMock.Verify(v => v.GetOrderId(Order));
        }
    }
}
