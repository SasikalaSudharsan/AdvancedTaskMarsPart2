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
                Wait.WaitToBeClickable(driver, "XPath", "//span[@class='item ui dropdown link']", 6);
                UserTab = driver.FindElement(By.XPath("//span[@class='item ui dropdown link']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void clickUserTab()
        {
            Thread.Sleep(6000);
            renderUserTab();
            UserTab.Click();
        }
    }
}
