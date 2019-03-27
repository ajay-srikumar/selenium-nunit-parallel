using NUnit.Framework;
using PartyboxJourneyTest.Framework;
using PartyboxJourneyTest.Pages;

namespace PartyboxJourneyTest.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class Test2 : BaseTest 
    {

        private LoginPage loginPage;

        [OneTimeSetUp]
        public void setup()
        {
            loginPage = new LoginPage(GetDriver());
        }
        
        [Test]
        [Retry(2)]
        public void LoginTest3()
        {
            loginPage.login("ajay", Utilities.Config.GetSection("users")["password"]);
        }

      
        [Test]
        [Retry(2)]
        public void LoginTest4()
        {
            loginPage.login("ajay", Utilities.Config.GetSection("users")["password"]);
        }
 
    }
}