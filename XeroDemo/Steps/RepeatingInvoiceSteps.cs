using TechTalk.SpecFlow;
using XeroDemo.Pages;

namespace XeroDemo.Steps
{
    [Binding]
    public class RepeatingInvoiceSteps : BaseSteps
    {
        [When(@"I navigate to Repeating Invoice Page")]
        public void WhenINavigateToRepeatingInvoicePage()
        {
            var repeatingInvicePage = new RepeatingInvoicePage();
            repeatingInvicePage.GotoRepeatingInvoicePage();
        }

        [Then(@"I should see Repeating Invoice page with correct content")]
        public void ThenIShouldSeeRepeatingInvoicePageWithCorrectContent()
        {
            var repeatingInvicePage = new RepeatingInvoicePage();
            repeatingInvicePage.VerifyPage();
        }

        [Given(@"I'm on Repeating Invoice Page")]
        public void GivenImOnRepeatingInvoicePage()
        {
            var loginSteps = new LoginSteps();
            loginSteps.LogInToTheStstem();
            WhenINavigateToRepeatingInvoicePage();
        }

        [When(@"I place a successfull Repeating Invoice")]
        public void WhenIPlaceASuccessfullRepeatingInvoice()
        {
            var repeatingInvicePage = new RepeatingInvoicePage();
            repeatingInvicePage.PlaceRepeatingInvoice();
        }

        [Then(@"I should see the confirmation message")]
        public void ThenIShouldSeeTheConfirmationMessage()
        {
            var repeatingInvicePage = new RepeatingInvoicePage();
            repeatingInvicePage.VerifyMessage();
        }

        [When(@"I place a Repeating Invoice without '(.*)'")]
        public void WhenIPlaceARepeatingInvoiceWithout(string missingItem)
        {
            var repeatingInvicePage = new RepeatingInvoicePage();
            repeatingInvicePage.PlaceRepeatingInvoice(missingItem);
        }

        [Then(@"I should see the '(.*)' message")]
        public void ThenIShouldSeeTheMessage(string errorMessage)
        {
            var repeatingInvicePage = new RepeatingInvoicePage();
            repeatingInvicePage.VerifyMessage(errorMessage);
        }
    }
}