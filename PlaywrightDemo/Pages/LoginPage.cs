using Microsoft.Playwright;

namespace PlaywrightDemo.Pages;

public class LoginPage
{
    private readonly ILocator _btnLogin;
    private readonly ILocator _lnkEmployeeDetails;
    private readonly ILocator _lnkLogin;
    private readonly ILocator _txtPassword;
    private readonly ILocator _txtUserName;

    private readonly IPage _page;

    public LoginPage(IPage page)
    {
        _page = page;
        _lnkLogin = _page.GetByRole(AriaRole.Link, new() { Name = "Login" });
        _txtUserName = _page.GetByLabel("UserName");
        _txtPassword = _page.GetByLabel("Password");
        _btnLogin = _page.GetByRole(AriaRole.Button,new() { Name= "Log in"} );
        _lnkEmployeeDetails = _page.GetByRole(AriaRole.Link, new() { Name = "Employee List" });
    }

    public async Task ClickLogin()
    {
        await _lnkLogin.ClickAsync();
    }

    public async Task Login(string userName, string password)
    {
        await _txtUserName.FillAsync(userName);
        await _txtPassword.FillAsync(password);
        await _btnLogin.ClickAsync();
    }

    public async Task<bool> IsEmployeeDetailsExists()
    {
        return await _lnkEmployeeDetails.IsVisibleAsync();
    }
}