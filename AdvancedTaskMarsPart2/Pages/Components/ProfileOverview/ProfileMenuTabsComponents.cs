using AdvancedTaskMarsPart2.Utilities;
using OpenQA.Selenium;

namespace AdvancedTaskMarsPart2.Pages.Components.ProfileOverview
{
    public class ProfileMenuTabsComponents : CommonDriver
    {
        private IWebElement EducationTab;
        private IWebElement CertificationsTab;
        private IWebElement DescriptionTab;

        public void renderEducationComponents()
        {
            try
            {
                Wait.WaitToBeClickable(driver, "XPath", "//a[text()='Education']", 4);
                EducationTab = driver.FindElement(By.XPath("//a[text()='Education']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void renderCertificationComponents()
        {
            try
            {
                Wait.WaitToBeClickable(driver, "XPath", "//a[text()='Certifications']", 4);
                CertificationsTab = driver.FindElement(By.XPath("//a[text()='Certifications']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void renderDescriptionComponents()
        {
            try
            {
                Wait.WaitToBeClickable(driver, "XPath", "//h3[text()='Description']/span/i[@class='outline write icon']", 6);
                DescriptionTab = driver.FindElement(By.XPath("//h3[text()='Description']/span/i[@class='outline write icon']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void clickEducationTab()
        {
            renderEducationComponents();
            EducationTab.Click();
            Thread.Sleep(4000);
        }

        public void clickCertificationsTab()
        {
            renderCertificationComponents();
            CertificationsTab.Click();
            Thread.Sleep(4000);
        }

        public void clickDescriptionIcon()
        {
            renderDescriptionComponents();
            DescriptionTab.Click();
            Thread.Sleep(4000);
        }
    }
}
