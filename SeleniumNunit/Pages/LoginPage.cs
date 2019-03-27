using OpenQA.Selenium;
using PartyboxJourneyTest.Framework;

namespace PartyboxJourneyTest.Pages
{
    public class LoginPage : WebDriverExtension
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {
            
        }
        
        By userNameText = By.Id("username");
        By passwordText = By.Id("password");
        By loginButton = By.Id("submit");
        
        
        public void login(string username, string password)
        {
            SetText(userNameText,username);
            SetText(passwordText,password);
            Click(loginButton);
        }

    }
}