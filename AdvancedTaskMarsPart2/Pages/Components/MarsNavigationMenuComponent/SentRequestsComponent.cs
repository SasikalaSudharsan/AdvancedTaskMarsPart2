using AdvancedTaskMarsPart2.Model;
using AdvancedTaskMarsPart2.Utilities;
using OpenQA.Selenium;

namespace AdvancedTaskMarsPart2.Pages.Components.MarsNavigationMenuComponent
{
    public class SentRequestsComponent : CommonDriver
    {
        private IWebElement WithdrawButton;
        private IWebElement successMessage;
        private IWebElement closeMessageIcon;

        public void renderWithdrawComponent(string title)
        {
            try
            {
                WithdrawButton = driver.FindElement(By.XPath($"//table[@class='ui single line sortable striped table sortableHeader']//a[text()='{title}']/../following-sibling::td[@class='two wide']/button[text()='Withdraw']   "));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void renderSuccessMessage()
        {
            try
            {
                successMessage = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
                closeMessageIcon = driver.FindElement(By.XPath("//*[@class='ns-close']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void clickWithdrawButton(SentRequestsData sentRequestsData)
        {
            Thread.Sleep(4000);
            string title = sentRequestsData.Title;
            renderWithdrawComponent(title);
            WithdrawButton.Click();
            Wait.WaitToBeVisible(driver, "XPath", "//div[@class='ns-box-inner']", 4);
        }

        public string getMessage()
        {
            renderSuccessMessage();
            string message = successMessage.Text;
            closeMessageIcon.Click();
            Thread.Sleep(6000);
            return message;
        }
    }
}
