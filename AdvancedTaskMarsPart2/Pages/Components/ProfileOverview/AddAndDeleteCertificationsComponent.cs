using AdvancedTaskMarsPart2.TestData;
using AdvancedTaskMarsPart2.Utilities;
using OpenQA.Selenium;

namespace AdvancedTaskMarsPart2.Pages.Components.ProfileOverview
{
    public class AddAndDeleteCertificationsComponent : CommonDriver
    {
        private IReadOnlyCollection<IWebElement> deleteButtons;
        private IWebElement CertificateTextbox;
        private IWebElement CertifiedFromTextbox;
        private IWebElement Year;
        private IWebElement AddButton;
        private IWebElement successMessage;
        private IWebElement closeMessageIcon;

        public void renderDeleteAllCertificationsComponents()
        {
            try
            {
                deleteButtons = driver.FindElements(By.XPath("//div[@data-tab='fourth']//i[@class='remove icon']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void renderAddComponents()
        {
            try
            {
                CertificateTextbox = driver.FindElement(By.XPath("//input[@name='certificationName']"));
                CertifiedFromTextbox = driver.FindElement(By.XPath("//input[@name='certificationFrom']"));
                Year = driver.FindElement(By.XPath("//select[@name='certificationYear']"));
                AddButton = driver.FindElement(By.XPath("//input[@value='Add']"));
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

        public void DeleteAllCertifications()
        {
            try
            {
                Wait.WaitToBeClickable(driver, "XPath", "//div[@data-tab='fourth']//i[@class='remove icon']", 6);
            }
            catch (WebDriverTimeoutException e)
            {
                return;
            }
            renderDeleteAllCertificationsComponents();
            //Delete all certifications in the list
            foreach (IWebElement deleteButton in deleteButtons)
            {
                deleteButton.Click();
            }
        }

        public void addCertification(CertificationData certificationData)
        {
            renderAddComponents();
            CertificateTextbox.SendKeys(certificationData.Certificate);
            CertifiedFromTextbox.SendKeys(certificationData.CertifiedFrom);
            Year.SendKeys(certificationData.Year);
            AddButton.Click();
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
