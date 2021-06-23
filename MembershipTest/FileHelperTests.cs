using Membership.Fake;
using Membership.Helper;
using NUnit.Framework;

namespace MembershipTest
{
    [TestFixture]
    public class FileHelperTests
    {
        private FileHelper fileHelper;

        [SetUp]
        public void Setip()
        {
            fileHelper = new FileHelper(new FakeReadService());
        }

        [Test]
        //[TestCase("test")]
        [TestCase(null)]
        public void ReadFile_WithNoPath_ReturnErrorMessage(string path)
        {
            Assert.That(() => fileHelper.ReadFile(path), Throws.ArgumentNullException);
        }

        [Test]
        [TestCase("path")]
        public void ReadFile_WithCorrectPath_ReturnText(string path)
        {
            var result = fileHelper.ReadFile(path);

            Assert.That(result, Does.Contain("file"));
        }
    }
}
