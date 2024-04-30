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

        [Given(@"User logged into Mars URL and navigates to Education tab")]
        public void GivenUserLoggedIntoMarsURLAndNavigatesToEducationTab()
        {
            signInComponent.clickSignInButton();
            List<UserInformation> userInformatioList = JsonReader.LoadData<UserInformation>(@"UserInformation.json");
            foreach (var userInformation in userInformatioList)
            {
                loginInComponent.LoginActions(userInformation);
            }
            profileMenuTabsComponents.clickEducationTab();
        }

        [When(@"Delete all records in the education list")]
        public void WhenDeleteAllRecordsInTheEducationList()
        {
            addAndDeleteEducationComponent.DeleteAllRecords();
        }

        [When(@"User creates a new education with '([^']*)'")]
        public void WhenUserCreatesANewEducationWith(int id)
        {
            EducationData educationData = JsonReader.LoadData<EducationData>(@"addEducationData.json").FirstOrDefault(x => x.Id == id);
            profileEducationOverviewComponent.clickAddNewButton();
            addAndDeleteEducationComponent.addEducation(educationData);
        }

        [Then(@"The education with '([^']*)' should be created successfully")]
        public void ThenTheEducationWithShouldBeCreatedSuccessfully(int id)
        {
            EducationData educationData = JsonReader.LoadData<EducationData>(@"addEducationData.json").FirstOrDefault(x => x.Id == id);
            string actualMessage = addAndDeleteEducationComponent.getMessage();
            EducationAssertHelper.assertAddEducationSuccessMessage(educationData.ExpectedMessage, actualMessage);
        }

        [When(@"User deletes an existing education with '([^']*)'")]
        public void WhenUserDeletesAnExistingEducationWith(int id)
        {
            EducationData educationData = JsonReader.LoadData<EducationData>(@"deleteEducationData.json").FirstOrDefault(x => x.Id == id);
            profileEducationOverviewComponent.clickDeleteButton(educationData);
        }

        [Then(@"The education with '([^']*)' should be deleted successfully")]
        public void ThenTheEducationWithShouldBeDeletedSuccessfully(int id)
        {
            EducationData educationData = JsonReader.LoadData<EducationData>(@"deleteEducationData.json").FirstOrDefault(x => x.Id == id);
            string actualMessage = addAndDeleteEducationComponent.getMessage();
            EducationAssertHelper.assertDeleteEducationSuccessMessage(educationData.ExpectedMessage, actualMessage);
        }
    }
}
