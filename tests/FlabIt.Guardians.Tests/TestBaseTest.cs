using NUnit.Framework;

namespace FlabIt.Guardians.Tests
{
    [TestFixture]
    public class TestBaseTest
    {
        [Test]
        public void When_creating_TestBase_loads_test_string_resources()
        {
            var sut = new TestBase();

            try
            {
                sut.BaseSetUp();

                Assert.NotNull(sut.TestBaseStringResources);
            }
            finally
            {
                sut.BaseTearDown();

                Assert.IsNull(sut.TestBaseStringResources);
            }
        }
    }
}