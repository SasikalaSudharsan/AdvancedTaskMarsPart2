using AdvancedTaskMarsPart2.TestData;
using AdvancedTaskMarsPart2.Utilities;
using OpenQA.Selenium;

namespace AdvancedTaskMarsPart2.Pages.Components.ProfileOverview
{
    public class ProfileCertificationsOverviewComponent : CommonDriver
    {
        private IWebElement AddNewButton;
        private IWebElement DeleteButton;

        public void renderAddButton()
        {
            try
            {
                AddNewButton = driver.FindElement(By.XPath("//div[@class='four wide column' and h3='Certification']/following-sibling::div[@class='twelve wide column scrollTable']//th[@class='right aligned']//div"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void renderDeleteButton(string certificate, string certifiedFrom)
        {
            try
            {
                DeleteButton = driver.FindElement(By.XPath($"//div[@data-tab='fourth']//tr[td[1]='{certificate}' and td[2] ='{certifiedFrom}']/td[last()]/span[2]"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void clickAddNewButton()
        {
            renderAddButton();
            AddNewButton.Click();
        }

        public void clickDeleteButton(CertificationData certificationData)
        {
            string certificate = certificationData.Certificate;
            string certifiedFrom = certificationData.CertifiedFrom;
            renderDeleteButton(certificate, certifiedFrom);
            DeleteButton.Click();
            Wait.WaitToBeVisible(driver, "XPath", "//div[@class='ns-box-inner']", 4);
        }
    }
}
