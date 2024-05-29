using AdvancedTaskMarsPart2.Model;
using AdvancedTaskMarsPart2.Utilities;
using OpenQA.Selenium;

namespace AdvancedTaskMarsPart2.Pages.Components.MarsNavigationMenuComponent
{
    public class ReceivedRequestsComponent : CommonDriver
    {
        private IWebElement AcceptButton;
        private IWebElement successMessage;
        private IWebElement closeMessageIcon;
        private IWebElement DeclineButton;
        private IWebElement CompleteButton;

        public void renderAcceptComponent(string title)
        {
            try
            {
                AcceptButton = driver.FindElement(By.XPath($"//table[@class='ui single line sortable striped table sortableHeader']//a[text()='{title}']/../following-sibling::td[@class='two wide']/button[text()='Accept']"));
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

        public void renderDeclineComponent(string title)
        {
            try
            {
                DeclineButton = driver.FindElement(By.XPath($"//table[@class='ui single line sortable striped table sortableHeader']//a[text()='{title}']/../following-sibling::td[@class='two wide']/button[text()='Decline']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void renderCompleteComponent(string title)
        {
            try
            {
                CompleteButton = driver.FindElement(By.XPath($"//table[@class='ui single line sortable striped table sortableHeader']//a[text()='{title}']/../following-sibling::td[@class='two wide']/button[text()='Complete']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void clickAcceptButton(ReceivedRequestsData receivedRequestsData)
        {
            Thread.Sleep(30000);
            string title = receivedRequestsData.Title;
            renderAcceptComponent(title);
            AcceptButton.Click();
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

        public void clickDeclineButton(ReceivedRequestsData receivedRequestsData)
        {
            Thread.Sleep(30000);
            string title = receivedRequestsData.Title;
            renderDeclineComponent(title);
            DeclineButton.Click();
            Wait.WaitToBeVisible(driver, "XPath", "//div[@class='ns-box-inner']", 4);
        }

        public void clickCompleteButton(ReceivedRequestsData receivedRequestsData)
        {
            Thread.Sleep(30000);
            string title = receivedRequestsData.Title;
            renderCompleteComponent(title);
            CompleteButton.Click();
            Wait.WaitToBeVisible(driver, "XPath", "//div[@class='ns-box-inner']", 4);
        }
    }
}
