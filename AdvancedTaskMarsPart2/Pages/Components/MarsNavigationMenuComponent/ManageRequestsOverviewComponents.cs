using AdvancedTaskMarsPart2.Utilities;
using OpenQA.Selenium;

namespace AdvancedTaskMarsPart2.Pages.Components.MarsNavigationMenuComponent
{
    public class ManageRequestsOverviewComponents : CommonDriver
    {
        private IWebElement ReceivedRequestsDropdown;
        private IWebElement SentRequestsDropdown;

        public void renderReceivedRequestsComponent()
        {
            try
            {
                Wait.WaitToBeClickable(driver, "XPath", "//a[text()='Received Requests']", 6);
                ReceivedRequestsDropdown = driver.FindElement(By.XPath("//a[text()='Received Requests']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void renderSentRequestsComponent()
        {
            try
            {
                Wait.WaitToBeClickable(driver, "XPath", "//a[text()='Sent Requests']", 6);
                SentRequestsDropdown = driver.FindElement(By.XPath("//a[text()='Sent Requests']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void clickReceivedRequests()
        {
            renderReceivedRequestsComponent();
            ReceivedRequestsDropdown.Click();
        }

        public void clickSentRequests()
        {
            renderSentRequestsComponent();
            SentRequestsDropdown.Click();
        }
    }
}
