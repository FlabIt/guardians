using NUnit.Framework;

namespace FlabIt.Guardians.Tests
{
    [TestFixture]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores", Justification = "Naming like this is convention in test methods.")]
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