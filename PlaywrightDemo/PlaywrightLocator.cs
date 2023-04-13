namespace PlaywrightDemo;

public class PlaywrightLocator
{
    [Test]
    public async Task LocatorTestsInPlaywright()
    {
        using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false,
        });
        var context = await browser.NewContextAsync();

        var page = await context.NewPageAsync();

        await page.GotoAsync("http://eaapp.somee.com/");

        await page.GetByRole(AriaRole.Link, new() { Name = "Login" }).ClickAsync();

        await page.GetByLabel("UserName").ClickAsync();

        await page.GetByLabel("UserName").FillAsync("admin");

        await page.GetByLabel("UserName").PressAsync("Tab");

        await page.GetByLabel("Password").FillAsync("password");

        await page.GetByRole(AriaRole.Button, new() { Name = "Log in" }).ClickAsync();

        await page.GetByRole(AriaRole.Link, new() { Name = "Employee List" }).ClickAsync();

        await page.GetByRole(AriaRole.Link, new() { Name = "Create New" }).ClickAsync();

        await page.GetByLabel("Name").ClickAsync();

        await page.GetByLabel("Name").FillAsync("Adam");

        await page.GetByLabel("Name").PressAsync("Tab");

        await page.GetByLabel("Salary").FillAsync("10000");

        await page.GetByLabel("Salary").PressAsync("Tab");

        await page.GetByLabel("DurationWorked").FillAsync("1");

        await page.GetByLabel("DurationWorked").PressAsync("Tab");

        await page.GetByLabel("Grade").FillAsync("1");

        await page.GetByLabel("Grade").PressAsync("Tab");

        await page.GetByLabel("Email").FillAsync("adam@adam.com");

        await page.GetByRole(AriaRole.Button, new() { Name = "Create" }).ClickAsync();

        await page
            .GetByRole(AriaRole.Row, new() { Name = "Adam" })
            .GetByRole(AriaRole.Link, new() { Name = "Delete" }).ClickAsync();

        await page.ScreenshotAsync(new()
        {
            Path = "screenshot.png",
            FullPage = true
        });
    }
}