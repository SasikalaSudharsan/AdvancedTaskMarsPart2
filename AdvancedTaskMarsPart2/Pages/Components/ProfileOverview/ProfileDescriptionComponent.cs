using AdvancedTaskMarsPart2.Model;
using AdvancedTaskMarsPart2.Utilities;
using OpenQA.Selenium;

namespace AdvancedTaskMarsPart2.Pages.Components.ProfileOverview
{
    public class ProfileDescriptionComponent : CommonDriver
    {
        private IWebElement DescriptionTextbox;
        private IWebElement SaveButton;
        private IWebElement successMessage;
        private IWebElement closeMessageIcon;

        public void renderComponents()
        {
            try
            {
                Wait.WaitToBeVisible(driver, "XPath", "//textarea[@name='value']", 4);
                DescriptionTextbox = driver.FindElement(By.XPath("//textarea[@name='value']"));
                SaveButton = driver.FindElement(By.XPath("//button[@type='button']"));
            }
            catch(Exception ex)
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

        public void enterDescription(DescriptionData descriptionData)
        {
            renderComponents();
            DescriptionTextbox.Clear();
            DescriptionTextbox.SendKeys(descriptionData.Description);
            SaveButton.Click();
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
