using AdvancedTaskMarsPart2.Model;
using AdvancedTaskMarsPart2.Utilities;
using OpenQA.Selenium;

namespace AdvancedTaskMarsPart2.Pages.Components.AccountMenu
{
    public class ChangePasswordComponent : CommonDriver
    {
        private IWebElement ChangePassword;
        private IWebElement CurrentPassword;
        private IWebElement NewPassword;
        private IWebElement ConfirmPassword;
        private IWebElement SaveButton;

        public void renderChangePassword()
        {
            try
            {
                ChangePassword = driver.FindElement(By.XPath("//a[text()='Change Password']"));
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

        public void changePassword(ChangePasswordData changePasswordData)
        {
            renderChangePassword();
            ChangePassword.Click();
            CurrentPassword.SendKeys(changePasswordData.CurrentPassword);
            NewPassword.SendKeys(changePasswordData.NewPassword);
            ConfirmPassword.SendKeys(changePasswordData.ConfirmPassword);
            SaveButton.Click();
        }
    }
}
