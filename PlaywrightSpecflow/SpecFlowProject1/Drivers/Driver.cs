using Microsoft.Playwright;

namespace SpecFlowProject1.Drivers;

public class Driver : IDisposable
{
    private readonly Task<IPage> _page;
    private IBrowser? _browser;

    public Driver()
    {
        _page = Task.Run(InitializePlaywright);
    }

    public IPage Page => _page.Result;

    public void Dispose()
    {
        _browser?.CloseAsync();
    }

    private async Task<IPage> InitializePlaywright()
    {
        //Playwright
        var playwright = await Playwright.CreateAsync();
        //Browser
        _browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false
        });
        //Page
        return await _browser.NewPageAsync();
    }
}