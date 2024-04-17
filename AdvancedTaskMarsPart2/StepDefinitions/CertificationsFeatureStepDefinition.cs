using AdvancedTaskMarsPart2.AssertHelpers;
using AdvancedTaskMarsPart2.Pages.Components.ProfileOverview;
using AdvancedTaskMarsPart2.Pages.Components.SignIn;
using AdvancedTaskMarsPart2.TestData;
using AdvancedTaskMarsPart2.Utilities;
using TechTalk.SpecFlow;

namespace AdvancedTaskMarsPart2.StepDefinitions
{
    [Binding]
    public class CertificationsFeatureStepDefinition : CommonDriver
    {
        SignInComponent signInComponent;
        LoginInComponent loginInComponent;
        ProfileMenuTabsComponents profileMenuTabsComponents;
        AddAndDeleteCertificationsComponent addAndDeleteCertificationsComponent;
        ProfileCertificationsOverviewComponent profileCertificationsOverviewComponent;

        public CertificationsFeatureStepDefinition()
        {
            signInComponent = new SignInComponent();
            loginInComponent = new LoginInComponent();
            profileMenuTabsComponents = new ProfileMenuTabsComponents();
            addAndDeleteCertificationsComponent = new AddAndDeleteCertificationsComponent();
            profileCertificationsOverviewComponent = new ProfileCertificationsOverviewComponent();
        }

        [Given(@"User logged into Mars URL and navigates to Certifications tab")]
        public void GivenUserLoggedIntoMarsURLAndNavigatesToCertificationsTab()
        {
            signInComponent.clickSignInButton();
            loginInComponent.LoginActions();
            profileMenuTabsComponents.clickCertificationsTab();
        }

        [When(@"Delete all records in the certifications list")]
        public void WhenDeleteAllRecordsInTheCertificationsList()
        {
            addAndDeleteCertificationsComponent.DeleteAllRecords();
        }

        [When(@"User creates a new certification with '([^']*)'")]
        public void WhenUserCreatesANewCertificationWith(int id)
        {
            CertificationData certificationData = JsonReader.LoadData<CertificationData>(@"addCertificationsData.json").FirstOrDefault(x => x.Id == id);
            profileCertificationsOverviewComponent.clickAddNewButton();
            addAndDeleteCertificationsComponent.addCertification(certificationData);
        }

        [Then(@"The certification with '([^']*)' should be created successfully")]
        public void ThenTheCertificationWithShouldBeCreatedSuccessfully(int id)
        {
            CertificationData certificationData = JsonReader.LoadData<CertificationData>(@"addCertificationsData.json").FirstOrDefault(x => x.Id == id);
            string actualMessage = addAndDeleteCertificationsComponent.getMessage();
            CertificationsAssertHelper.assertAddCertificationSuccessMessage(certificationData.ExpectedMessage, actualMessage);
            Console.WriteLine(actualMessage);
        }

        [When(@"User deletes an existing certification with '([^']*)'")]
        public void WhenUserDeletesAnExistingCertificationWith(int id)
        {
            CertificationData certificationData = JsonReader.LoadData<CertificationData>(@"deleteCertificationsData.json").FirstOrDefault(x => x.Id == id);
            profileCertificationsOverviewComponent.clickDeleteButton(certificationData);
        }

        [Then(@"The certification with '([^']*)' should be deleted successfully")]
        public void ThenTheCertificationWithShouldBeDeletedSuccessfully(int id)
        {
            CertificationData certificationData = JsonReader.LoadData<CertificationData>(@"deleteCertificationsData.json").FirstOrDefault(x => x.Id == id);
            string actualMessage = addAndDeleteCertificationsComponent.getMessage();
            CertificationsAssertHelper.assertDeleteCertificationSuccessMessage(certificationData.ExpectedMessage, actualMessage);
            Console.WriteLine(actualMessage);
        }

    }
}
