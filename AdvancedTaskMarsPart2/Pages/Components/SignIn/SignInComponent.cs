using AdvancedTaskMarsPart2.Utilities;
using OpenQA.Selenium;

namespace AdvancedTaskMarsPart2.Pages.Components.SignIn
{
    public class SignInComponent : CommonDriver
    {
        private IWebElement SignInButton;

        public void renderSignIn()
        {
            try
            {
                Wait.WaitToBeClickable(driver, "XPath", "//div[@id='home']/div/div/div/div/a", 4);
                SignInButton = driver.FindElement(By.XPath("//div[@id='home']/div/div/div/div/a"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void clickSignInButton()
        {
            renderSignIn();
            SignInButton.Click();
        }
    }
}
