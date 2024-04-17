using AdvancedTaskMarsPart2.Utilities;
using OpenQA.Selenium;

namespace AdvancedTaskMarsPart2.Pages.Components.MarsNavigationMenuComponent
{
    public class ManageListingsTabComponents : CommonDriver
    {
        private IWebElement ManageListingsTab;

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

        public void clickManageListingsTab()
        {
            renderManageListings();
            ManageListingsTab.Click();
        }
    }
}
