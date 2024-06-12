using AdvancedTaskMarsPart2.Utilities;
using OpenQA.Selenium;

namespace AdvancedTaskMarsPart2.Pages.Components.AccountMenu
{
    public class UserTabComponent : CommonDriver
    {
        private IWebElement UserTab;

        public void renderUserTab()
        {
            try
            {
                Wait.WaitToBeClickable(driver, "XPath", "//*[starts-with(text(),'Hi')]", 4);
                UserTab = driver.FindElement(By.XPath("//*[starts-with(text(),'Hi')]"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void clickUserTab()
        {
            renderUserTab();
            UserTab.Click();
        }
    }
}
