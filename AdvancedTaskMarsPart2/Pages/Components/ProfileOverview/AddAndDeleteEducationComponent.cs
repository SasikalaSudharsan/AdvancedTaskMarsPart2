using AdvancedTaskMarsPart2.TestData;
using AdvancedTaskMarsPart2.Utilities;
using OpenQA.Selenium;

namespace AdvancedTaskMarsPart2.Pages.Components.ProfileOverview
{
    public class AddAndDeleteEducationComponent : CommonDriver
    {
        private IReadOnlyCollection<IWebElement> deleteButtons;
        private IWebElement UniversityNameTextbox;
        private IWebElement CountryOfUniversity;
        private IWebElement Title;
        private IWebElement Degree;
        private IWebElement YearOfGraduation;
        private IWebElement AddButton;
        private IWebElement successMessage;
        private IWebElement closeMessageIcon;

        public void renderDeleteAllRecordsComponents()
        {
            try
            {
                deleteButtons = driver.FindElements(By.XPath("//div[@data-tab='third']//i[@class='remove icon']"));
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
                UniversityNameTextbox = driver.FindElement(By.XPath("//input[@name='instituteName']"));
                CountryOfUniversity = driver.FindElement(By.XPath("//select[@name='country']"));
                Title = driver.FindElement(By.XPath("//select[@name='title']"));
                Degree = driver.FindElement(By.XPath("//input[@name='degree']"));
                YearOfGraduation = driver.FindElement(By.XPath("//select[@name='yearOfGraduation']"));
                AddButton = driver.FindElement(By.XPath("//input[@value='Add']"));
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

        public void DeleteAllRecords()
        {
            try
            {
                Wait.WaitToBeClickable(driver, "XPath", "//div[@data-tab='third']//i[@class='remove icon']", 4);
            }
            catch (WebDriverTimeoutException e)
            {
                return;
            }
            renderDeleteAllRecordsComponents();
            //Delete all records in the list
            foreach (IWebElement deleteButton in deleteButtons)
            {
                deleteButton.Click();
            }
        }

        public void addEducation(EducationData educationData)
        {
            renderAddComponents();
            UniversityNameTextbox.SendKeys(educationData.UniversityName);
            CountryOfUniversity.SendKeys(educationData.Country);
            Title.SendKeys(educationData.Title);
            Degree.SendKeys(educationData.Degree);
            YearOfGraduation.SendKeys(educationData.YearOfGraduation);
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
