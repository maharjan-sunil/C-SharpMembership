using Membership.Helper;
using Membership.Implementation.Interface;
using Membership.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace MembershipTest
{
    [TestFixture]
    public class FileHelperTests
    {
        private FileHelper _fileHelper;
        private Mock<IFile> _file;

        [SetUp]
        public void Setip()
        {
            _file = new Mock<IFile>();
            _fileHelper = new FileHelper(_file.Object);
        }

        [Test]
        [TestCase(null)]
        public void ReadFile_WithNoPath_ReturnErrorMessage(string path)
        {
            _file.Setup(f => f.Read(null)).Throws(new ArgumentNullException());

            Assert.That(() => _fileHelper.ReadFile(path), Throws.ArgumentNullException);
        }

        //[Test]
        //[TestCase("path")]
        //public void ReadFile_WithCorrectPath_ReturnText(string path)
        //{
        //    var result = _fileHelper.ReadFile(path);

        //    Assert.That(result, Does.Contain("file"));
        //}

        //[Test]
        //public void ReadFile_WithEmptyPath_ReturnErrorMessage()
        //{
        //    var fileReader = new Mock<IFile>();
        //    fileReader.Setup(f => f.Read(null)).Throws(new ArgumentNullException());

        //    var fileHelper = new FileHelper(fileReader.Object);

        //    Assert.That(() => fileHelper.ReadFile(null), Throws.ArgumentNullException);
        //}

        //[Test]
        //public void GetListOfFileString_WithCorrectPath_ReturnListOfFileString()
        //{
        //    var fileReader = new Mock<IFile>();
        //    fileReader.Setup(f => f.GetFiles("File.txt")).Returns(new List<BaseEntityModel>());

        //    var fileHelper = new FileHelper(fileReader.Object);

        //    var result = fileHelper.GetListOfFile("File.txt");
        //    Assert.That(result, Is.EqualTo(new List<BaseEntityModel>()));
        //}

        //[Test]
        //public void GetListOfFileString_WithEmptyPath_ReturnErrorMessage()
        //{
        //    var fileReader = new Mock<IFile>();
        //    fileReader.Setup(f => f.GetFiles(null)).Throws(new ArgumentNullException());

        //    var fileHelper = new FileHelper(fileReader.Object);

        //    Assert.That(() => fileHelper.GetListOfFile(null), Throws.ArgumentNullException);
        //}
    }
}
