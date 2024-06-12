using AdvancedTaskMarsPart2.AssertHelpers;
using AdvancedTaskMarsPart2.Model;
using AdvancedTaskMarsPart2.Pages.Components.ProfileOverview;
using AdvancedTaskMarsPart2.Pages.Components.SignIn;
using AdvancedTaskMarsPart2.Utilities;
using TechTalk.SpecFlow;

namespace AdvancedTaskMarsPart2.StepDefinitions
{
    [Binding]
    public class DescriptionFeatureStepDefinition
    {
        SignInComponent signInComponent;
        LoginInComponent loginInComponent;
        ProfileMenuTabsComponents profileMenuTabsComponents;
        ProfileDescriptionComponent profileDescriptionComponent;

        public DescriptionFeatureStepDefinition()
        {
            signInComponent = new SignInComponent();
            loginInComponent = new LoginInComponent();
            profileMenuTabsComponents = new ProfileMenuTabsComponents();
            profileDescriptionComponent = new ProfileDescriptionComponent();
        }

        [Given(@"User logged into Mars URL with login details '([^']*)' and navigates to Description icon")]
        public void GivenUserLoggedIntoMarsURLWithLoginDetailsAndNavigatesToDescriptionIcon(int id)
        {
            UserInformation userInformation = JsonReader.LoadData<UserInformation>(@"UserInformation.json").FirstOrDefault(x => x.Id == id);
            signInComponent.clickSignInButton();
            loginInComponent.LoginActions(userInformation);
            profileMenuTabsComponents.clickDescriptionIcon();
        }

        [When(@"User adds description '([^']*)' in the profile page")]
        public void WhenUserAddsDescriptionInTheProfilePage(int id)
        {
            DescriptionData descriptionData = JsonReader.LoadData<DescriptionData>(@"addDescriptionData.json").FirstOrDefault(x => x.Id == id);
            profileDescriptionComponent.enterDescription(descriptionData);
        }

        [Then(@"The description '([^']*)' should be saved successfully")]
        public void ThenTheDescriptionShouldBeSavedSuccessfully(int id)
        {
            DescriptionData descriptionData = JsonReader.LoadData<DescriptionData>(@"addDescriptionData.json").FirstOrDefault(x => x.Id == id);
            string actualMessage = profileDescriptionComponent.getMessage();
            DescriptionAssertHelper.assertAddDescriptionSuccessMessage(descriptionData.ExpectedMessage, actualMessage);
        }
    }
}
