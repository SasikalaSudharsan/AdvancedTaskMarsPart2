using AdvancedTaskMarsPart2.AssertHelpers;
using AdvancedTaskMarsPart2.Model;
using AdvancedTaskMarsPart2.Pages.Components.MarsNavigationMenuComponent;
using AdvancedTaskMarsPart2.Pages.Components.SignIn;
using AdvancedTaskMarsPart2.Utilities;
using TechTalk.SpecFlow;

namespace AdvancedTaskMarsPart2.StepDefinitions
{
    [Binding]
    public class ManageListingsFeatureStepDefinition
    {
        SignInComponent signInComponent;
        LoginInComponent loginInComponent;
        NavigationMenuTabsComponents navigationMenuTabsComponents;
        ManageListingsOverviewComponents manageListingsOverviewComponents;
        ManageListingsComponent manageListingsComponent;

        public ManageListingsFeatureStepDefinition()
        {
            signInComponent = new SignInComponent();
            loginInComponent = new LoginInComponent();
            navigationMenuTabsComponents = new NavigationMenuTabsComponents();
            manageListingsOverviewComponents = new ManageListingsOverviewComponents();
            manageListingsComponent = new ManageListingsComponent();
        }

        [Given(@"User logged into Mars URL with login details '([^']*)' and navigates to Manage Listings tab")]
        public void GivenUserLoggedIntoMarsURLWithLoginDetailsAndNavigatesToManageListingsTab(int id)
        {
            UserInformation userInformation = JsonReader.LoadData<UserInformation>(@"UserInformation.json").FirstOrDefault(x => x.Id == id);
            signInComponent.clickSignInButton();
            loginInComponent.LoginActions(userInformation);
            navigationMenuTabsComponents.clickManageListingsTab();
        }

        [Given(@"User adds a shareSkill '([^']*)' in the Manage Listings")]
        public void GivenUserAddsAShareSkillInTheManageListings(int id)
        {
            ShareSkillData shareSkillData = JsonReader.LoadData<ShareSkillData>(@"ShareSkillData.json").FirstOrDefault(x => x.Id == id);
            manageListingsOverviewComponents.clickShareSkillButton();
            manageListingsComponent.addShareSkill(shareSkillData);
            navigationMenuTabsComponents.clickManageListingsTab();
            string newTitle = manageListingsComponent.getTitle(shareSkillData.Title);
            ManageListingsAssertHelper.assertUpdateManageListingsSuccessMessage(shareSkillData.Title, newTitle);
        }

        [When(@"User edits and update the skills with '([^']*)' in the Manage Listings")]
        public void WhenUserEditsAndUpdateTheSkillsWithInTheManageListings(int id)
        {
            ShareSkillData shareSkillData = JsonReader.LoadData<ShareSkillData>(@"ShareSkillData.json").FirstOrDefault(x => x.Id == id);
            manageListingsOverviewComponents.clickUpdateButton(shareSkillData);
            manageListingsComponent.updateShareSkill(shareSkillData);
        }

        [Then(@"The skills with '([^']*)' are updated successfully")]
        public void ThenTheSkillsWithAreUpdatedSuccessfully(int id)
        {
            ShareSkillData shareSkillData = JsonReader.LoadData<ShareSkillData>(@"ShareSkillData.json").FirstOrDefault(x => x.Id == id);
            navigationMenuTabsComponents.clickManageListingsTab();
            string newTitle = manageListingsComponent.getTitle(shareSkillData.UpdateTitle);
            ManageListingsAssertHelper.assertUpdateManageListingsSuccessMessage(shareSkillData.UpdateTitle, newTitle);
        }

        [When(@"User view the skills with '([^']*)' in the Manage Listings")]
        public void WhenUserViewTheSkillsWithInTheManageListings(int id)
        {
            ShareSkillData shareSkillData = JsonReader.LoadData<ShareSkillData>(@"ShareSkillData.json").FirstOrDefault(x => x.Id == id);
            manageListingsOverviewComponents.clickViewButton(shareSkillData);
        }

        [Then(@"The skills with '([^']*)' are viewed in detail successfully")]
        public void ThenTheSkillsWithAreViewedInDetailSuccessfully(int id)
        {
            ShareSkillData shareSkillData = JsonReader.LoadData<ShareSkillData>(@"ShareSkillData.json").FirstOrDefault(x => x.Id == id);
            string viewTitle = manageListingsOverviewComponents.getViewTitle(shareSkillData.UpdateTitle);
            ManageListingsAssertHelper.assertViewManageListingsSuccessMessage(shareSkillData.UpdateTitle, viewTitle);
        }


        [When(@"User deletes the skill with '([^']*)' in the Manage Listings")]
        public void WhenUserDeletesTheSkillWithInTheManageListings(int id)
        {
            ShareSkillData shareSkillData = JsonReader.LoadData<ShareSkillData>(@"ShareSkillData.json").FirstOrDefault(x => x.Id == id);
            navigationMenuTabsComponents.clickManageListingsTab();
            manageListingsOverviewComponents.clickDeleteButton(shareSkillData);
        }

        [Then(@"The skill with '([^']*)' are deleted successfully")]
        public void ThenTheSkillWithAreDeletedSuccessfully(int id)
        {
            string actualMessage = manageListingsOverviewComponents.getMessage();
            ManageListingsAssertHelper.assertDeleteManageListingsSuccessMessage("Selenium has been deleted", actualMessage);
        }

        [When(@"User deactivates the existing skill with '([^']*)'")]
        public void WhenUserDeactivatesTheExistingSkillWith(int id)
        {
            ShareSkillData shareSkillData = JsonReader.LoadData<ShareSkillData>(@"ShareSkillData.json").FirstOrDefault(x => x.Id == id);
            manageListingsOverviewComponents.disableActiveCheckbox(shareSkillData);
        }

        [Then(@"The skill should be deactivated successfully")]
        public void ThenTheSkillShouldBeDeactivatedSuccessfully()
        {
            string actualMessage = manageListingsOverviewComponents.getMessage();
            ManageListingsAssertHelper.assertDisableManageListingsSuccessMessage("Service has been deactivated", actualMessage);
        }

        [When(@"User activates the existing skill with '([^']*)'")]
        public void WhenUserActivatesTheExistingSkillWith(int id)
        {
            ShareSkillData shareSkillData = JsonReader.LoadData<ShareSkillData>(@"ShareSkillData.json").FirstOrDefault(x => x.Id == id);
            manageListingsOverviewComponents.enableActiveCheckbox(shareSkillData);
        }

        [Then(@"The skill should be activated successfully")]
        public void ThenTheSkillShouldBeActivatedSuccessfully()
        {
            string actualMessage = manageListingsOverviewComponents.getMessage();
            ManageListingsAssertHelper.assertEnableManageListingsSuccessMessage("Service has been activated", actualMessage);
        }
    }
}
