using AdvancedTaskMarsPart2.Model;
using AdvancedTaskMarsPart2.Utilities;
using OpenQA.Selenium;

namespace AdvancedTaskMarsPart2.Pages.Components.MarsNavigationMenuComponent
{
    public class ManageListingsOverviewComponents : CommonDriver
    {
        private IWebElement EditButton;
        private IWebElement DeleteButton;
        private IWebElement YesButton;
        private IWebElement successMessage;
        private IWebElement ActiveCheckbox;
        private IWebElement ViewButton;
        private IWebElement ViewTitle;

        public void renderEditButton(string existingTitle)
        {
            try
            {
                EditButton = driver.FindElement(By.XPath($"//td[text()='{existingTitle}']/following-sibling::td/div/button[@class='ui button']/i[@class='outline write icon']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void renderViewComponents(string title)
        {
            try
            {
                ViewButton = driver.FindElement(By.XPath($"//td[text()='{title}']/following-sibling::td/div/button[@class='ui button']/i[@class='eye icon']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void renderViewTitle(string title)
        {
            try
            {
                ViewTitle = driver.FindElement(By.XPath($"//span[text()='{title}']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void renderDeleteButton(string title)
        {
            try
            {
                DeleteButton = driver.FindElement(By.XPath($"//td[text()='{title}']/following-sibling::td/div/button[@class='ui button']/i[@class='remove icon']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void renderYesButton()
        {
            try
            {
                YesButton = driver.FindElement(By.XPath("//button[@class='ui icon positive right labeled button']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void renderMessage()
        {
            try
            {
                Wait.WaitToBeVisible(driver, "XPath", "//div[@class='ns-box-inner']", 4);
                successMessage = driver.FindElement(By.XPath("//div[@class='ns-box-inner']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void renderActiveChechbox(string title)
        {
            try
            {
                ActiveCheckbox = driver.FindElement(By.XPath($"//td[text()='{title}']/following-sibling::td/div[@class='ui toggle checkbox']"));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void clickUpdateButton(ShareSkillData shareSkillData)
        {
            string existingTitle = shareSkillData.ExistingTitle;
            Thread.Sleep(6000);
            renderEditButton(existingTitle);
            EditButton.Click();
        }

        public void clickViewButton(ShareSkillData shareSkillData)
        {
            string title = shareSkillData.Title;
            Thread.Sleep(6000);
            renderViewComponents(title);
            ViewButton.Click();
        }

        public string getViewTitle(string title)
        {
            Thread.Sleep(4000);
            renderViewTitle(title);
            return ViewTitle.Text;
        }

        public void clickDeleteButton(ShareSkillData shareSkillData)
        {
            string title = shareSkillData.Title;
            Thread.Sleep(6000);
            renderDeleteButton(title);
            DeleteButton.Click();
            renderYesButton();
            YesButton.Click();
        }

        public string getMessage()
        {
            renderMessage();
            return successMessage.Text;
        }

        public void disableActiveCheckbox(ManageListingsData manageListingsData)
        {
            string title = manageListingsData.Title;
            Thread.Sleep(6000);
            renderActiveChechbox(title);
            ActiveCheckbox.Click();
        }

        public void enableActiveCheckbox(ManageListingsData manageListingsData)
        {
            string title = manageListingsData.Title;
            Thread.Sleep(4000);
            renderActiveChechbox(title);
            ActiveCheckbox.Click();
        }
    }
}