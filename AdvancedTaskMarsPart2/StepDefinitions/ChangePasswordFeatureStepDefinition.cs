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

        [Given(@"User logged into Mars URL and navigates to User tab")]
        public void GivenUserLoggedIntoMarsURLAndNavigatesToUserTab()
        {
            signInComponent.clickSignInButton();
            loginInComponent.LoginActions();
            userTabComponent.clickUserTab();
        }

        [When(@"User clicks Change Password and updates the new password with '([^']*)'")]
        public void WhenUserClicksChangePasswordAndUpdatesTheNewPasswordWith(int id)
        {
            ChangePasswordData changePasswordData = JsonReader.LoadData<ChangePasswordData>(@"changePassword.json").FirstOrDefault(x => x.Id == id);
            changePasswordComponent.changePassword(changePasswordData);
        }

        [Then(@"New Password updated with '([^']*)' successfully")]
        public void ThenNewPasswordUpdatedWithSuccessfully(string p0)
        {
            throw new PendingStepException();
        }

    }
}
