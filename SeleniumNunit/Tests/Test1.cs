using NUnit.Framework;
using PartyboxJourneyTest.Framework;
using PartyboxJourneyTest.Pages;

namespace PartyboxJourneyTest.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class Test1 : BaseTest 
    {

        private LoginPage loginpage;

        [OneTimeSetUp]
        public void setup()
        {
            loginpage = new LoginPage(GetDriver());
        }
        
        [Test]
        [Retry(2)]
        public void LoginTest1()
        {
           loginpage.login("aj", Utilities.Config.GetSection("users")["password"]);
        }

      
        [Test]
        [Retry(2)]
        public void LoginTest2()
        {
            loginpage.login("ajay", Utilities.Config.GetSection("users")["password"]);

        }
 
    }
}