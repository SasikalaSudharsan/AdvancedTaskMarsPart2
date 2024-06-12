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

        [Given(@"User logged into Mars URL with login details '([^']*)' and navigates to Certifications tab")]
        public void GivenUserLoggedIntoMarsURLWithLoginDetailsAndNavigatesToCertificationsTab(int id)
        {
            UserInformation userInformation = JsonReader.LoadData<UserInformation>(@"UserInformation.json").FirstOrDefault(x => x.Id == id);
            signInComponent.clickSignInButton();
            loginInComponent.LoginActions(userInformation);
            profileMenuTabsComponents.clickCertificationsTab();
        }

        [Given(@"Delete all certifications in the certifications list")]
        public void GivenDeleteAllCertificationsInTheCertificationsList()
        {
            addAndDeleteCertificationsComponent.DeleteAllCertifications();
        }

        [When(@"User adds a new certification '([^']*)' and should be added successfully")]
        public void WhenUserAddsANewCertificationAndShouldBeAddedSuccessfully(int id)
        {
            CertificationData certificationData = JsonReader.LoadData<CertificationData>(@"certificationsData.json").FirstOrDefault(x => x.Id == id);
            profileCertificationsOverviewComponent.clickAddNewButton();
            addAndDeleteCertificationsComponent.addCertification(certificationData);
            string actualMessage = addAndDeleteCertificationsComponent.getMessage();
            CertificationsAssertHelper.assertAddCertificationMessage(certificationData.AddExpectedMessage, actualMessage);
        }

        [When(@"User deletes certification '([^']*)' and should be deleted successfully")]
        public void WhenUserDeletesCertificationAndShouldBeDeletedSuccessfully(int id)
        {
            CertificationData certificationData = JsonReader.LoadData<CertificationData>(@"certificationsData.json").FirstOrDefault(x => x.Id == id);
            profileCertificationsOverviewComponent.clickDeleteButton(certificationData);
            string actualMessage = addAndDeleteCertificationsComponent.getMessage();
            CertificationsAssertHelper.assertDeleteCertificationSuccessMessage(certificationData.DeleteExpectedMessage, actualMessage);
        }

        [Given(@"User has a certification '([^']*)' in the certifications list")]
        public void GivenUserHasACertificationInTheCertificationsList(int id)
        {
            CertificationData certificationData = JsonReader.LoadData<CertificationData>(@"existsCertificationsData.json").FirstOrDefault(x => x.Id == id);
            profileCertificationsOverviewComponent.clickAddNewButton();
            addAndDeleteCertificationsComponent.addCertification(certificationData);
            addAndDeleteCertificationsComponent.getMessage();
        }

        [When(@"User tries to add the certification '([^']*)' again")]
        public void WhenUserTriesToAddTheCertificationAgain(int id)
        {
            CertificationData certificationData = JsonReader.LoadData<CertificationData>(@"existsCertificationsData.json").FirstOrDefault(x => x.Id == id);
            profileCertificationsOverviewComponent.clickAddNewButton();
            addAndDeleteCertificationsComponent.addCertification(certificationData);
        }

        [Then(@"The certification '([^']*)' should not be added")]
        public void ThenTheCertificationShouldNotBeAdded(int id)
        {
            CertificationData certificationData = JsonReader.LoadData<CertificationData>(@"existsCertificationsData.json").FirstOrDefault(x => x.Id == id);
            string actualMessage = addAndDeleteCertificationsComponent.getMessage();
            CertificationsAssertHelper.assertAddCertificationMessage(certificationData.ExpectedMessage, actualMessage);
        }

        [When(@"User tries to add empty certification '([^']*)' in the certifications list")]
        public void WhenUserTriesToAddEmptyCertificationInTheCertificationsList(int id)
        {
            CertificationData certificationData = JsonReader.LoadData<CertificationData>(@"emptyCertificationsData.json").FirstOrDefault(x => x.Id == id);
            profileCertificationsOverviewComponent.clickAddNewButton();
            addAndDeleteCertificationsComponent.addCertification(certificationData);
        }

        [Then(@"The certification '([^']*)' should not allow empty certification")]
        public void ThenTheCertificationShouldNotAllowEmptyCertification(int id)
        {
            CertificationData certificationData = JsonReader.LoadData<CertificationData>(@"emptyCertificationsData.json").FirstOrDefault(x => x.Id == id);
            string actualMessage = addAndDeleteCertificationsComponent.getMessage();
            CertificationsAssertHelper.assertAddCertificationMessage(certificationData.ExpectedMessage, actualMessage);
        }

        [When(@"User tries to add special characters in the certification '([^']*)'")]
        public void WhenUserTriesToAddSpecialCharactersInTheCertification(int id)
        {
            CertificationData certificationData = JsonReader.LoadData<CertificationData>(@"specialCharsCertificationsData.json").FirstOrDefault(x => x.Id == id);
            profileCertificationsOverviewComponent.clickAddNewButton();
            addAndDeleteCertificationsComponent.addCertification(certificationData);
        }

        [Then(@"The certification '([^']*)' should not allow special characters")]
        public void ThenTheCertificationShouldNotAllowSpecialCharacters(int id)
        {
            CertificationData certificationData = JsonReader.LoadData<CertificationData>(@"specialCharsCertificationsData.json").FirstOrDefault(x => x.Id == id);
            string actualMessage = addAndDeleteCertificationsComponent.getMessage();
            CertificationsAssertHelper.assertAddCertificationMessage(certificationData.ExpectedMessage, actualMessage);
        }
    }
}
