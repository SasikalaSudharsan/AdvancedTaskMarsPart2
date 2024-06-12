using AdvancedTaskMarsPart2.TestData;
using AdvancedTaskMarsPart2.Utilities;
using OpenQA.Selenium;

namespace AdvancedTaskMarsPart2.Pages.Components.ProfileOverview
{
    public class ProfileEducationOverviewComponent : CommonDriver
    {
        private IWebElement AddNewButton;
        private IWebElement DeleteButton;

        public void renderAddButton()
        {
            try
            {
                AddNewButton = driver.FindElement(By.XPath("//div[@class='four wide column' and h3='Education']/following-sibling::div[@class='twelve wide column scrollTable']//th[@class='right aligned']//div"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void renderDeleteButton(string country, string universityName, string degree)
        {
            try
            {
                DeleteButton = driver.FindElement(By.XPath($"//div[@data-tab='third']//tr[td[1]='{country}' and td[2]='{universityName}' and td[4]='{degree}']/td[last()]/span[2]"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void clickAddNewButton()
        {
            Thread.Sleep(8000);
            renderAddButton();
            AddNewButton.Click();
        }

        public void clickDeleteButton(EducationData educationData)
        {
            string country = educationData.Country;
            string universityName = educationData.UniversityName;
            string degree = educationData.Degree;
            renderDeleteButton(country, universityName, degree);
            DeleteButton.Click();
            Wait.WaitToBeVisible(driver, "XPath", "//div[@class='ns-box-inner']", 4);
        }
    }
}
