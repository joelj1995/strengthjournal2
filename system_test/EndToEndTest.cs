using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using system_test.Harness;

namespace system_test
{
    public class EndToEndTest
    {
        [SetUp]
        public void Setup()
        {
            application = new ApplicationRunner();
        }

        [TearDown]
        public void Teardown()
        {
            application.Dispose();
        }

        [Test]
        public void TestLoginToApplication()
        {
            application.Login();
            Assert.That(application.ShowsWelcomeMessage());
        }

        private ApplicationRunner application;
    }
}