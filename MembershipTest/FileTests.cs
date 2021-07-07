using Membership.Fake;
using Membership.Implementation.DataManager;
using Membership.Implementation.Interface;
using Membership.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace MembershipTest
{
    [TestFixture]
    public class FileTests
    {
        private FileDataManager dataManager;
        private Mock<IFile> fileMock;

        [SetUp]
        public void Setup()
        {
            //using mock
            fileMock = new Mock<IFile>();
            dataManager = new FileDataManager(fileMock.Object);

            //using fake service
            //   dataManager = new FileDataManager(new FakeReadService());
        }

        //[Test]
        //[TestCase(null)]
        //[TestCase("")]
        //public void ReadFile_WithNoPath_ReturnErrorMessage(string path)
        //{
        //    Assert.That(() => dataManager.ReadFile(path), Throws.ArgumentNullException);
        //}

        //[Test]
        //[TestCase("path")]
        //public void ReadFile_WithCorrectPath_ReturnText(string path)
        //{
        //    var result = dataManager.ReadFile(path);

        //    Assert.That(result, Does.Contain("file"));
        //}

        [Test]
        public void ReadFile_WithEmptyPath_ReturnErrorMessage()
        {
            fileMock.Setup(f => f.Read(null)).Throws(new ArgumentNullException());

            Assert.That(() => dataManager.ReadFile(null), Throws.ArgumentNullException);
        }

        [Test]
        [TestCase("correctPath")]
        public void ReadFile_WithCorrectPath_ReturnErrorMessage(string path)
        {
            fileMock.Setup(f => f.Read(path)).Returns("file data");

            Assert.That(() => dataManager.ReadFile(path), Does.Contain("file"));
        }

        [Test]
        [TestCase("correctpath")]
        public void GetListOfFileString_WithCorrectPath_ReturnListOfFileString(string path)
        {
            fileMock.Setup(f => f.GetFiles(path)).Returns(new List<BaseEntityModel>());

            var result = dataManager.GetListOfFile(path);

            Assert.That(result, Is.EqualTo(new List<BaseEntityModel>()));
        }

        [Test]
        public void GetListOfFileString_WithEmptyPath_ReturnErrorMessage()
        {
            fileMock.Setup(f => f.GetFiles(null)).Throws(new ArgumentNullException());

            Assert.That(() => dataManager.GetListOfFile(null), Throws.ArgumentNullException);
        }

        [Test]
        public void GetFile_WithEmptyPath_ReturnErrorMessage()
        {
            fileMock.Setup(f => f.FileOnly(null)).Throws(new ArgumentNullException());

            Assert.That(() => dataManager.GetFile(null), Throws.ArgumentNullException);
        }
    }
}
