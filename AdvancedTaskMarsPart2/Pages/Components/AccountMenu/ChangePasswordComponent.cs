using AdvancedTaskMarsPart2.Model;
using AdvancedTaskMarsPart2.Utilities;
using OpenQA.Selenium;

namespace AdvancedTaskMarsPart2.Pages.Components.AccountMenu
{
    public class ChangePasswordComponent : CommonDriver
    {
        private IWebElement ChangePasswordDropdown;
        private IWebElement CurrentPassword;
        private IWebElement NewPassword;
        private IWebElement ConfirmPassword;
        private IWebElement SaveButton;
        private IWebElement successMessage;

        public void renderChangePasswordDropdown()
        {
            try
            {
                Wait.WaitToBeClickable(driver, "XPath", "//a[text()='Change Password']", 4);
                ChangePasswordDropdown = driver.FindElement(By.XPath("//a[text()='Change Password']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void renderChangePasswordComponents()
        {
            try
            {
                Wait.WaitToExist(driver, "XPath", "//input[@placeholder='Current Password']", 4);
                CurrentPassword = driver.FindElement(By.XPath("//input[@placeholder='Current Password']"));
                NewPassword = driver.FindElement(By.XPath("//input[@placeholder='New Password']"));
                ConfirmPassword = driver.FindElement(By.XPath("//input[@placeholder='Confirm Password']"));
                SaveButton = driver.FindElement(By.XPath("//button[@type='button']"));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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

        public void changePassword(ChangePasswordData changePasswordData)
        {
            renderChangePasswordDropdown();
            ChangePasswordDropdown.Click();
            renderChangePasswordComponents();
            CurrentPassword.SendKeys(changePasswordData.CurrentPassword);
            NewPassword.SendKeys(changePasswordData.NewPassword);
            ConfirmPassword.SendKeys(changePasswordData.ConfirmPassword);
            SaveButton.Click();
        }

        public string getMessage()
        {
            renderMessage();
            return successMessage.Text;
        }
    }
}
