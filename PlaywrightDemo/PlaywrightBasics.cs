using System.IO;
using System.Reflection;

namespace PlaywrightDemo;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public async Task Test1()
    {
        //Playwright
        using var playwright = await Playwright.CreateAsync();
        //Browser
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false
        });
        //Page
        var page = await browser.NewPageAsync();
        await page.GotoAsync("http://www.eaapp.somee.com");
        await page.ClickAsync("text=Login");
        await page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = "EAApp.jpg"
        });
        await page.FillAsync("#UserName", "admin");
        await page.FillAsync("#Password", "password");
        await page.ClickAsync("text=Log in");
        var isExist = await page.Locator("text='Employee Details'").IsVisibleAsync();
        Assert.IsTrue(isExist);
    }

    [Test]
    public async Task TestWithPOM()
    {
        //Playwright
        using var playwright = await Playwright.CreateAsync();
        //Browser
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false
        });
        //Page
        var page = await browser.NewPageAsync();
        await page.GotoAsync("http://www.eaapp.somee.com");

        var loginPage = new LoginPageUpgraded(page);
        await loginPage.ClickLogin();
        await loginPage.Login("admin", "password");
        var isExist = await loginPage.IsEmployeeDetailsExists();
        Assert.IsTrue(isExist);
    }


    [Test]
    public async Task WaitTest()
    {
        using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false
        });
        var context = await browser.NewContextAsync();
        var page = await context.NewPageAsync();
        await page.GotoAsync("https://demos.telerik.com/kendo-ui/window/angular");
        await page.Locator(
                "text=Calendar May 2022SuMoTuWeThFrSa1234567891011121314151617181920212223242526272829 >> [aria-label=\"Close\"]")
            .ClickAsync();
        await page.Locator(
                "text=Calendar May 2022SuMoTuWeThFrSa1234567891011121314151617181920212223242526272829 >> [aria-label=\"Close\"]")
            .ClickAsync();
        // Click button:has-text("Open AJAX content")
        await page.Locator("button:has-text(\"Open AJAX content\")").ClickAsync();
    }

    [Test]
    public async Task TestNetwork()
    {
        //Playwright
        using var playwright = await Playwright.CreateAsync();
        //Browser
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false
        });
        //Page
        var page = await browser.NewPageAsync();
        await page.GotoAsync("http://www.eaapp.somee.com");

        var loginPage = new LoginPageUpgraded(page);
        await loginPage.ClickLogin();
        await loginPage.Login("admin", "password");

        //Wait for response - Way 1
        var waitResponse = page.WaitForResponseAsync("**/Employee");
        //while the button is clicked
        await loginPage.ClickEmployeeList();
        //give the response details
        var getResponse = await waitResponse;

        //Way 2 - Wait for response
        var response = await page.RunAndWaitForResponseAsync(async () => { await loginPage.ClickEmployeeList(); },
            x => x.Url.Contains("/Employee") && x.Status == 200);

        var isExist = await loginPage.IsEmployeeDetailsExists();
        Assert.IsTrue(isExist);
    }

    [Test]
    public async Task Flipkart()
    {
        using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false
        });
        var context = await browser.NewContextAsync();
        var page = await context.NewPageAsync();
        await page.GotoAsync("https://www.flipkart.com/", new PageGotoOptions
        {
            WaitUntil = WaitUntilState.NetworkIdle
        });
        await page.Locator("text=✕").ClickAsync();

        await page.Locator("a", new PageLocatorOptions
        {
            HasTextString = "Login"
        }).ClickAsync();

        var request = await page.RunAndWaitForRequestAsync(async () => { await page.Locator("text=✕").ClickAsync(); },
            x => x.Url.Contains("flipkart.d1.sc.omtrdc.net") && x.Method == "GET");

        var returnData = HttpUtility.UrlDecode(request.Url);

        returnData.Should().Contain("Account Login:Displayed Exit");
    }

    [Test]
    public async Task? FlipkartNetworkInterception()
    {
        using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false
        });
        var context = await browser.NewContextAsync();
        var page = await context.NewPageAsync();

        page.Request += (_, request) => Console.WriteLine(request.Method + "---" + request.Url);
        page.Response += (_, response) => Console.WriteLine(response.Status + "---" + response.Url);

        await page.RouteAsync("**/*", async route =>
        {
            if (route.Request.ResourceType == "image")
                await route.AbortAsync();
            else
                await route.ContinueAsync();
        });

        await page.GotoAsync("https://www.flipkart.com/", new PageGotoOptions
        {
            WaitUntil = WaitUntilState.NetworkIdle
        });
    }


    [Test]
    public async Task TestForHar()
    {
        //Playwright
        using var playwright = await Playwright.CreateAsync();
        //Browser
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false
        });

        //Page
        var page = await browser.NewPageAsync(new BrowserNewPageOptions
        {
            RecordHarPath = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}/eapp.har"
            //RecordHarUrlFilter = "**/Product/**"
        });


        await page.RouteFromHARAsync($"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}/eapp.har",
            new PageRouteFromHAROptions
            {
                Url = "**/Product/List",
                Update = false
            });

        await page.GotoAsync("http://localhost:5001/");

        await page.GetByRole(AriaRole.Link, new PageGetByRoleOptions { Name = "Product" }).ClickAsync();

        await page.GetByRole(AriaRole.Link, new PageGetByRoleOptions { Name = "Create" }).ClickAsync();

        await page.GetByLabel("Name").ClickAsync();

        await page.GetByLabel("Name").FillAsync("karthik");

        await page.GetByLabel("Name").PressAsync("Tab");

        await page.GetByLabel("Description").FillAsync("12");

        await page.GetByLabel("Description").PressAsync("Tab");

        await page.Locator("#Price").FillAsync("100");

        await page.Locator("#Price").PressAsync("Tab");

        await page.GetByLabel("ProductType").SelectOptionAsync(new[] { "1" });

        await page.GetByRole(AriaRole.Button, new PageGetByRoleOptions { Name = "Create" }).ClickAsync();

        await Task.Delay(1000);

        await page.CloseAsync();
    }
}