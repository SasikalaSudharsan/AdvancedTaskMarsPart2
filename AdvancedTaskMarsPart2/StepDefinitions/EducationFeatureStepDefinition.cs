using AdvancedTaskMarsPart2.AssertHelpers;
using AdvancedTaskMarsPart2.Model;
using AdvancedTaskMarsPart2.Pages.Components.ProfileOverview;
using AdvancedTaskMarsPart2.Pages.Components.SignIn;
using AdvancedTaskMarsPart2.TestData;
using AdvancedTaskMarsPart2.Utilities;
using TechTalk.SpecFlow;

namespace AdvancedTaskMarsPart2.StepDefinitions
{
    [Binding]
    public class EducationFeatureStepDefinition : CommonDriver
    {
        SignInComponent signInComponent;
        LoginInComponent loginInComponent;
        ProfileMenuTabsComponents profileMenuTabsComponents;
        AddAndDeleteEducationComponent addAndDeleteEducationComponent;
        ProfileEducationOverviewComponent profileEducationOverviewComponent;

        public EducationFeatureStepDefinition()
        {
            signInComponent = new SignInComponent();
            loginInComponent = new LoginInComponent();
            profileMenuTabsComponents = new ProfileMenuTabsComponents();
            addAndDeleteEducationComponent = new AddAndDeleteEducationComponent();
            profileEducationOverviewComponent = new ProfileEducationOverviewComponent();
        }

        [Given(@"User logged into Mars URL with login details '([^']*)' and navigates to Education tab")]
        public void GivenUserLoggedIntoMarsURLWithLoginDetailsAndNavigatesToEducationTab(int id)
        {
            UserInformation userInformation = JsonReader.LoadData<UserInformation>(@"UserInformation.json").FirstOrDefault(x => x.Id == id);
            signInComponent.clickSignInButton();
            loginInComponent.LoginActions(userInformation);
            profileMenuTabsComponents.clickEducationTab();
        }

        [Given(@"Delete all educations in the education list")]
        public void GivenDeleteAllEducationsInTheEducationList()
        {
            addAndDeleteEducationComponent.DeleteAllEducation();
        }

        [When(@"User adds a new education '([^']*)' and should be added successfully")]
        public void WhenUserAddsANewEducationAndShouldBeAddedSuccessfully(int id)
        {
            EducationData educationData = JsonReader.LoadData<EducationData>(@"educationData.json").FirstOrDefault(x => x.Id == id);
            profileEducationOverviewComponent.clickAddNewButton();
            addAndDeleteEducationComponent.addEducation(educationData);
            string actualMessage = addAndDeleteEducationComponent.getMessage();
            EducationAssertHelper.assertAddEducationSuccessMessage(educationData.AddExpectedMessage, actualMessage);
        }

        [When(@"User deletes education '([^']*)' and should be deleted successfully")]
        public void WhenUserDeletesEducationAndShouldBeDeletedSuccessfully(int id)
        {
            EducationData educationData = JsonReader.LoadData<EducationData>(@"educationData.json").FirstOrDefault(x => x.Id == id);
            profileEducationOverviewComponent.clickDeleteButton(educationData);
            string actualMessage = addAndDeleteEducationComponent.getMessage();
            EducationAssertHelper.assertDeleteEducationSuccessMessage(educationData.DeleteExpectedMessage, actualMessage);
        }

        [Given(@"User has education '([^']*)' in the education list")]
        public void GivenUserHasEducationInTheEducationList(int id)
        {
            EducationData educationData = JsonReader.LoadData<EducationData>(@"existsEducationData.json").FirstOrDefault(x => x.Id == id);
            profileEducationOverviewComponent.clickAddNewButton();
            addAndDeleteEducationComponent.addEducation(educationData);
            addAndDeleteEducationComponent.getMessage();
        }

        [When(@"User tries to add education '([^']*)' again")]
        public void WhenUserTriesToAddEducationAgain(int id)
        {
            EducationData educationData = JsonReader.LoadData<EducationData>(@"existsEducationData.json").FirstOrDefault(x => x.Id == id);
            profileEducationOverviewComponent.clickAddNewButton();
            addAndDeleteEducationComponent.addEducation(educationData);
        }

        [Then(@"The education '([^']*)' should not be added again")]
        public void ThenTheEducationShouldNotBeAddedAgain(int id)
        {
            EducationData educationData = JsonReader.LoadData<EducationData>(@"existsEducationData.json").FirstOrDefault(x => x.Id == id);
            string actualMessage = addAndDeleteEducationComponent.getMessage();
            EducationAssertHelper.assertAddEducationSuccessMessage(educationData.ExpectedMessage, actualMessage);
        }

        [When(@"User tries to add empty education '([^']*)' in the education list")]
        public void WhenUserTriesToAddEmptyEducationInTheEducationList(int id)
        {
            EducationData educationData = JsonReader.LoadData<EducationData>(@"emptyEducationData.json").FirstOrDefault(x => x.Id == id);
            profileEducationOverviewComponent.clickAddNewButton();
            addAndDeleteEducationComponent.addEducation(educationData);
        }

        [Then(@"The education '([^']*)' should not allow empty education")]
        public void ThenTheEducationShouldNotAllowEmptyEducation(int id)
        {
            EducationData educationData = JsonReader.LoadData<EducationData>(@"emptyEducationData.json").FirstOrDefault(x => x.Id == id);
            string actualMessage = addAndDeleteEducationComponent.getMessage();
            EducationAssertHelper.assertAddEducationSuccessMessage(educationData.ExpectedMessage, actualMessage);
        }

        [When(@"User tries to add special characters '([^']*)' in the education")]
        public void WhenUserTriesToAddSpecialCharactersInTheEducation(int id)
        {
            EducationData educationData = JsonReader.LoadData<EducationData>(@"specialCharsEducationData.json").FirstOrDefault(x => x.Id == id);
            profileEducationOverviewComponent.clickAddNewButton();
            addAndDeleteEducationComponent.addEducation(educationData);
        }

        [Then(@"The education '([^']*)' should not allow special characters")]
        public void ThenTheEducationShouldNotAllowSpecialCharacters(int id)
        {
            EducationData educationData = JsonReader.LoadData<EducationData>(@"specialCharsEducationData.json").FirstOrDefault(x => x.Id == id);
            string actualMessage = addAndDeleteEducationComponent.getMessage();
            EducationAssertHelper.assertAddEducationSuccessMessage(educationData.ExpectedMessage, actualMessage);
        }
    }
}
