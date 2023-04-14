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

    [Test]
    public async Task LocatorTestForEA()
    {
 using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false,
        });
        var context = await browser.NewContextAsync();

        var page = await context.NewPageAsync();

        await page.GotoAsync("https://executeautomation.com/");

        await page.GetByRole(AriaRole.Link, new() { Name = "Sign In" }).ClickAsync();

        await page.GetByRole(AriaRole.Link, new() { Name = "Sign Up" }).ClickAsync();
        
        await page.GetByPlaceholder("First Name").FillAsync("DemoUser1");

        await page.GetByPlaceholder("Last Name").FillAsync("KK");

        await page.Locator("#react-select-2-input").FillAsync("New");

        await page.GetByText("New Zealand", new() { Exact = true }).ClickAsync();

        await page.GetByPlaceholder("Email Address").FillAsync("demouser1@demo1.com");

        await page.GetByPlaceholder("Password", new() { Exact = true }).FillAsync("password");

        await page.GetByPlaceholder("Enter Password Again").FillAsync("password");

        await page.GetByPlaceholder("Profession").FillAsync("Tester");

        await page.GetByRole(AriaRole.Button, new() { Name = "Create Account" }).ClickAsync();

        await page.Locator("img:nth-child(2)").ClickAsync();

        await page.GetByRole(AriaRole.Button, new() { Name = "Create Account" }).ClickAsync();

        await page.Locator(".ct-logo-header").ClickAsync();

        await page.GetByRole(AriaRole.Link, new() { Name = "Codeless automation Lean" }).ClickAsync();

        await page.GetByRole(AriaRole.Link, new() { Name = "1 Katalon Studio" }).ClickAsync();

        await page.GetByRole(AriaRole.Button, new() { Name = "Watch" }).ClickAsync();

        await page.GetByRole(AriaRole.Heading, new() { Name = "Part 2 - Record & playback," }).ClickAsync();

        await page.GetByRole(AriaRole.Button, new() { Name = "Close" }).ClickAsync();
    }


    [Test]
    public async Task LocatorTestsForEA2()
    {
        using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false,
        });
        var context = await browser.NewContextAsync();

        var page = await context.NewPageAsync();

        await page.GotoAsync("http://localhost:8000/Product/Create");

        var form1 = page.GetByRole(AriaRole.Form, new() { Name = "form1" });
        var form2 = page.GetByRole(AriaRole.Form, new() { Name = "form2" });

        await form1.GetByLabel("Name").FillAsync("keyboard");

        await form1.GetByLabel("Description").FillAsync("gaming keyboard");

        await form1.GetByRole(AriaRole.Spinbutton).FillAsync("20");

        await form1.Locator("#ProductType").SelectOptionAsync(new[] { "1" });

        await form2.Locator("#Name").FillAsync("Mouse");

        await form2.Locator("#Description").FillAsync("Gaming mouse");

        await form2.GetByRole(AriaRole.Spinbutton).FillAsync("10");

        await form2.Locator("#ProductType").SelectOptionAsync(new[] { "1" });

    }
}