using System.Threading;
using NUnit.Framework;

namespace FlabIt.Guardians.Tests
{
    public class TestBase
    {
        public TestBaseStringResources TestBaseStringResources { get; private set; }

        [SetUp]
        public void BaseSetUp()
        {
            TestBaseStringResources = new TestBaseStringResources(Thread.CurrentThread.CurrentCulture);
        }

        [TearDown]
        public void BaseTearDown()
        {
            TestBaseStringResources = null;
        }
    }
}