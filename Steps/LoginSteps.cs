using TechTalk.SpecFlow;
using XeroDemo.Pages;

namespace XeroDemo.Steps
{
    [Binding]
    internal class LoginSteps : BaseSteps
    {
        [Given(@"I'm on the login page")]
        public void GivenImOnTheLoginPage()
        {
            var loginPage = new LoginPage();
            loginPage.GotoLoginPage();
        }

        [Given(@"I login to the system")]
        public void LogInToTheStstem()
        {
            GivenImOnTheLoginPage();
            EnterCorrectUsernameAndPassword();
            ThenIShouldSeeMainDashBoard();
        }

        [When(@"I enter correct username and password")]
        public void EnterCorrectUsernameAndPassword()
        {
            var loginPage = new LoginPage();
            loginPage.LoginToTheSystem();
        }

        [Then(@"I should see main dash board")]
        public void ThenIShouldSeeMainDashBoard()
        {
            var dashBoardPage = new DashBoardPage();
            dashBoardPage.VerifyPage();
        }
    }
}