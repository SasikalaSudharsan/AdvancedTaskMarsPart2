using AdvancedTaskMarsPart2.Utilities;
using OpenQA.Selenium;

namespace AdvancedTaskMarsPart2.Pages.Components.MarsNavigationMenuComponent
{
    public class NavigationMenuTabsComponents : CommonDriver
    {
        private IWebElement ManageListingsTab;
        private IWebElement ManageRequestsTab;

        public void renderManageListings()
        {
            try
            {
                Wait.WaitToBeClickable(driver, "XPath", "//a[text()='Manage Listings']", 6);
                ManageListingsTab = driver.FindElement(By.XPath("//a[text()='Manage Listings']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void renderManageRequests()
        {
            try
            {
                Wait.WaitToBeClickable(driver, "XPath", "//div[text()='Manage Requests']", 6);
                ManageRequestsTab = driver.FindElement(By.XPath("//div[text()='Manage Requests']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void clickManageListingsTab()
        {
            renderManageListings();
            ManageListingsTab.Click();
        }

        public void clickManageRequestsTab()
        {
            renderManageRequests();
            ManageRequestsTab.Click();
        }
    }
}
