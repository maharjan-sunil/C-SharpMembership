using Membership.Implementation.DataManager;
using Membership.Implementation.Interface;
using Membership.Models;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace MembershipTest
{
    [TestFixture]
    public class OrderTests
    {
        private OrderDataManager dataManager;
        private Mock<IOrder> orderMock;
        [SetUp]
        public void Setup()
        {
            orderMock = new Mock<IOrder>();
            dataManager = new OrderDataManager(orderMock.Object);

        }
        [Test]
        public void OverLappingOrderExist_WhenCalledWithStatusFalse_ReturnEmptyString()
        {
            orderMock.Setup(x => x.GetList()).Returns(new List<Order>
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
            });

            var result = dataManager.GetOverLappingOrder(new Order
            {
                Status = false
            });
            Assert.That(result, Is.Empty);
        }
        [Test]
        public void OverLappingOrderExist_ButNoOtherData_ReturnEmptyString()
        {
            orderMock.Setup(x => x.GetList()).Returns(new List<Order>
            {
                 new Order
                {
                    Id=1,
                    Status = true,
                    ReferenceId = "10"
                }
            });

            var result = dataManager.GetOverLappingOrder(new Order
            {
                Id=1,
                Status = true,
                ReferenceId = "10"
            });
            Assert.That(result, Is.Empty);
        }
        [Test]
        public void OverLappingOrderExist_IfOverLapExist_ReturnFirstOrderReferenceId()
        {
            orderMock.Setup(x => x.GetList()).Returns(new List<Order>
            {
                 new Order
                {
                    Id=2,
                    Status = true,
                    ReferenceId = "100"
                }
            });

            var result = dataManager.GetOverLappingOrder(new Order
            {
                Id = 1,
                Status = true,
                ReferenceId = "10"
            });
            Assert.That(result, Is.EqualTo("100"));
        }
    }
}