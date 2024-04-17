using AdvancedTaskMarsPart2.Model;
using AdvancedTaskMarsPart2.Utilities;
using OpenQA.Selenium;

namespace AdvancedTaskMarsPart2.Pages.Components.MarsNavigationMenuComponent
{
    public class ManageListingsComponent : CommonDriver
    {
        private IWebElement TitleTextbox;
        private IWebElement DescriptionTextbox;
        private IWebElement StartDate;
        private IWebElement EndDate;
        private IWebElement SaveButton;
        private IWebElement newTitle;

        public void renderUpdateComponents()
        {
            try
            {
                Wait.WaitToBeVisible(driver, "XPath", "//input[@name='title']", 4);
                TitleTextbox = driver.FindElement(By.XPath("//input[@name='title']"));
                DescriptionTextbox = driver.FindElement(By.XPath("//textarea[@name='description']"));
                StartDate = driver.FindElement(By.XPath("//input[@placeholder='Start date']"));
                EndDate = driver.FindElement(By.XPath("//input[@placeholder='End date']"));
                SaveButton = driver.FindElement(By.XPath("//input[@value='Save']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void renderTitle(string title)
        {
            try
            {
                newTitle = driver.FindElement(By.XPath($"//td[@class='four wide'][text()='{title}'][1]"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void updateShareSkill(ShareSkillData shareSkillData)
        {
            renderUpdateComponents();
            TitleTextbox.Clear();
            TitleTextbox.SendKeys(shareSkillData.Title);
            DescriptionTextbox.Clear();
            DescriptionTextbox.SendKeys(shareSkillData.Description);
            StartDate.SendKeys(shareSkillData.StartDate);
            EndDate.SendKeys(shareSkillData.EndDate);
            SaveButton.Click();
        }

        public string getTitle(string title)
        {
            Thread.Sleep(6000);
            renderTitle(title);
            return newTitle.Text;
        }
    }
}
