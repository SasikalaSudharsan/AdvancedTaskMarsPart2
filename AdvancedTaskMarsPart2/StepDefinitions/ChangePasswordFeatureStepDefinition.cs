using AdvancedTaskMarsPart2.AssertHelpers;
using AdvancedTaskMarsPart2.Model;
using AdvancedTaskMarsPart2.Pages.Components.AccountMenu;
using AdvancedTaskMarsPart2.Pages.Components.SignIn;
using AdvancedTaskMarsPart2.Utilities;
using TechTalk.SpecFlow;

namespace AdvancedTaskMarsPart2.StepDefinitions
{
    [Binding]
    public class ChangePasswordFeatureStepDefinition
    {
        SignInComponent signInComponent;
        LoginInComponent loginInComponent;
        UserTabComponent userTabComponent;
        ChangePasswordComponent changePasswordComponent;

        public ChangePasswordFeatureStepDefinition()
        {
            signInComponent = new SignInComponent();
            loginInComponent = new LoginInComponent();
            userTabComponent = new UserTabComponent();
            changePasswordComponent = new ChangePasswordComponent();
        }

        [Given(@"User logged into Mars URL with login details '([^']*)' and navigates to User tab")]
        public void GivenUserLoggedIntoMarsURLWithLoginDetailsAndNavigatesToUserTab(int id)
        {
            UserInformation userInformation = JsonReader.LoadData<UserInformation>(@"UserInformation.json").FirstOrDefault(x => x.Id == id);
            signInComponent.clickSignInButton();
            loginInComponent.LoginActions(userInformation);
            userTabComponent.clickUserTab();
        }

        [When(@"User clicks Change Password and updates the new password with '([^']*)'")]
        public void WhenUserClicksChangePasswordAndUpdatesTheNewPasswordWith(int id)
        {
            ChangePasswordData changePasswordData = JsonReader.LoadData<ChangePasswordData>(@"passwordValidData.json").FirstOrDefault(x => x.Id == id);
            changePasswordComponent.changePassword(changePasswordData);
        }

        [Then(@"New Password '([^']*)' updated successfully")]
        public void ThenNewPasswordUpdatedSuccessfully(int id)
        {
            ChangePasswordData changePasswordData = JsonReader.LoadData<ChangePasswordData>(@"passwordValidData.json").FirstOrDefault(x => x.Id == id);
            string actualMessage = changePasswordComponent.getMessage();
            ChangePasswordAssertHelper.assertChangePasswordMessage(changePasswordData.ExpectedMessage, actualMessage);
            string newPassword = changePasswordData.NewPassword;
            PasswordManager passwordManager = new PasswordManager();
            passwordManager.WriteNewPasswordToJson(newPassword);
        }

        [When(@"User clicks Change Password and updates the new password with invalid '([^']*)'")]
        public void WhenUserClicksChangePasswordAndUpdatesTheNewPasswordWithInvalid(int id)
        {
            ChangePasswordData changePasswordData = JsonReader.LoadData<ChangePasswordData>(@"passwordInvalidData.json").FirstOrDefault(x => x.Id == id);
            changePasswordComponent.changePassword(changePasswordData);
        }

        [Then(@"The Password '([^']*)' should not be updated")]
        public void ThenThePasswordShouldNotBeUpdated(int id)
        {
            ChangePasswordData changePasswordData = JsonReader.LoadData<ChangePasswordData>(@"passwordInvalidData.json").FirstOrDefault(x => x.Id == id);
            string actualMessage = changePasswordComponent.getMessage();
            ChangePasswordAssertHelper.assertChangePasswordMessage(changePasswordData.ExpectedMessage, actualMessage);
        }
    }
}
