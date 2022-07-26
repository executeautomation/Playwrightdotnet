using Microsoft.Playwright;

namespace PlaywrightAPITesting.Driver;

public class PlaywrightDriver : IDisposable
{
    private readonly Task<IAPIRequestContext?>? _requestContext;

    public PlaywrightDriver()
    {
        _requestContext = CreateApiContext();
    }

    public IAPIRequestContext? ApiRequestContext => _requestContext?.GetAwaiter().GetResult();

    public void Dispose()
    {
        _requestContext?.Dispose();
    }


    private async Task<IAPIRequestContext?> CreateApiContext()
    {
        var playwright = await Playwright.CreateAsync();

        return await playwright.APIRequest.NewContextAsync(new APIRequestNewContextOptions
        {
            BaseURL = "https://localhost:5001/",
            IgnoreHTTPSErrors = true
        });
    }
}