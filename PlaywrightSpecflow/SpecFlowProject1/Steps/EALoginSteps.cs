using NUnit.Framework;
using SpecFlowProject1.Drivers;
using SpecFlowProject1.Pages;
using TechTalk.SpecFlow.Assist;

namespace SpecFlowProject1.Steps;

[Binding]
public sealed class EALoginSteps
{
    private readonly Driver _driver;
    private readonly LoginPage _loginPage;

    public EALoginSteps(Driver driver)
    {
        _driver = driver;
        _loginPage = new LoginPage(_driver.Page);
    }

    [Given(@"I navigate to appliacation")]
    public async Task GivenINavigateToAppliacation()
    {
        await _driver.Page.GotoAsync("http://www.eaapp.somee.com");
    }

    [Given(@"I enter following login details")]
    public async Task GivenIEnterFollowingLoginDetails(Table table)
    {
        dynamic data = table.CreateDynamicInstance();
        await _loginPage.Login((string)data.UserName, (string)data.Password);
    }

    [Then(@"I see Employee Lists")]
    public async Task ThenISeeEmployeeLists()
    {
        var isExist = await _loginPage.IsEmployeeDetailsExists();
        Assert.IsTrue(isExist);
    }

    [Given(@"I click login link")]
    public async Task GivenIClickLoginLink()
    {
        await _loginPage.ClickLogin();
    }
}