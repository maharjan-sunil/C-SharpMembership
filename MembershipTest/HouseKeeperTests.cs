using Membership.Helper;
using Membership.Implementation.Interface;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MembershipTest
{
    [TestFixture]
    public class HouseKeeperTests
    {
        private Mock<IHouseKeeper> _serviceMock;
        private Mock<IEmail> _emailMock;
        private Mock<IUnitOfWork> _unitOfWorkMock;
        private Mock<IMessage> _message;

        private Housekeeper housekeeper;
        private HousekeeperHelper helper;

        [SetUp]
        public void Setup()
        {
            _serviceMock = new Mock<IHouseKeeper>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _emailMock = new Mock<IEmail>();
            _message = new Mock<IMessage>();

            housekeeper = new Housekeeper
            {
                Email = "sunil@gmail.com",
                FullName = "Sunil Maharjan",
                Oid = 1,
                StatementEmailBody = "test"
            };

            helper = new HousekeeperHelper(
                                            _unitOfWorkMock.Object,
                                            _serviceMock.Object,
                                            _emailMock.Object,
                                            _message.Object);

            _unitOfWorkMock.Setup(uow => uow.Query<Housekeeper>()).Returns(new List<Housekeeper>
            {
                housekeeper
            }.AsQueryable());
        }

        private DateTime GetDateTime()
        {
            return new DateTime(2021, 7, 11);
        }

        [Test]
        public void SendStatementEmails_WithList_ShouldInvokdeGenerateStatment()
        {
            helper.SendStatementEmails(GetDateTime());

            _serviceMock.Verify(s => s.SaveStatement(1, "Sunil Maharjan", GetDateTime()));
        }

        [Test]
        public void SendStatementEmails_WithEmptyEmail_ShouldNeverGenerateStatment()
        {
            housekeeper.Email = null;

            helper.SendStatementEmails(GetDateTime());

            _serviceMock.Verify(s => s.SaveStatement(1, "Sunil Maharjan", GetDateTime()), Times.Never);
        }

        [Test]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void SendStatementEmails_WhenExecutedWithEmptyWhiteOrNullFileName_ShouldNotEmailAnUser(string _statementFileName)
        {
            _serviceMock
                .Setup(s => s.SaveStatement(housekeeper.Oid,
                                          housekeeper.FullName,
                                          GetDateTime()))
                .Returns(_statementFileName);

            helper.SendStatementEmails(GetDateTime());

            _emailMock
                .Verify(s => s.EmailFile(housekeeper.Email,
                                                 housekeeper.StatementEmailBody,
                                                 _statementFileName,
                                                 It.IsAny<string>()), Times.Never);

        }

        [Test]
        [TestCase("FileName")]
        public void SendStatementEmails_WhenExecutedWithFileName_ShouldEmailAnUser(string _statementFileName)
        {
            _serviceMock
                .Setup(s => s.SaveStatement(housekeeper.Oid,
                                          housekeeper.FullName,
                                          GetDateTime()))
                .Returns(_statementFileName);

            helper.SendStatementEmails(GetDateTime());

            _emailMock
                .Verify(s => s.EmailFile(housekeeper.Email,
                                                 housekeeper.StatementEmailBody,
                                                 _statementFileName,
                                                 It.IsAny<string>()));

        }

        [Ignore("some exception")]
        public void SendStatementEmails_WhenSomeException_ThrowAnError()
        {
            _emailMock
                .Setup(s => s.EmailFile(It.IsAny<String>(),
                                        It.IsAny<String>(),
                                        It.IsAny<String>(),
                                        It.IsAny<String>())).Throws(new Exception());

            helper.SendStatementEmails(GetDateTime());

            _message
                .Verify(m => m.Show(),Times.Once);
        }

        [Test]
        [TestCase(null)]
        public void TestExceptionCase_WithNull_ThrowArgumentNullException(string name)
        {
            helper.TestExceptionCase(name);
            _message
                .Verify(m => m.Show());
        }
    }
}
