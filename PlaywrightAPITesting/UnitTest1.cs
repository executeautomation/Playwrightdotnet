using System.Text.Json;
using FluentAssertions;
using Microsoft.Playwright;
using PlaywrightAPITesting.Driver;
using Xunit.Abstractions;
namespace PlaywrightAPITesting;

public class UnitTest1 : IClassFixture<PlaywrightDriver>
{
    private readonly PlaywrightDriver _playwrightDriver;
    private readonly ITestOutputHelper _testOutputHelper;


    public UnitTest1(PlaywrightDriver playwrightDriver, ITestOutputHelper testOutputHelper)
    {
        _playwrightDriver = playwrightDriver;
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public async Task AuthenticateTest()
    {
        var response = await _playwrightDriver.ApiRequestContext?.PostAsync("api/Authenticate/Login",
            new APIRequestContextOptions
            {
                DataObject = new
                {
                    UserName = "KK",
                    Password = "123456"
                }
            })!;


        var jsonString = await response.JsonAsync();

        // var token = jsonString?.GetProperty("token").ToString();

        var authencationResponse = jsonString?.Deserialize<Authenticate>(new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        _testOutputHelper.WriteLine(jsonString.ToString());


        authencationResponse?.Token.Should().NotBeNull();
        authencationResponse?.Token.Should().NotBe(string.Empty);
    }


    [Fact]
    public async Task GetProduct()
    {
        var token = await GetToken();

        var response = await _playwrightDriver.ApiRequestContext?.GetAsync("Product/GetProductById/1",
            new APIRequestContextOptions
            {
                Headers = new Dictionary<string, string>
                {
                    { "Authorization", $"Bearer {token}" }
                }
            })!;

        var data = await response.JsonAsync();

        _testOutputHelper.WriteLine(data.ToString());

        //Reference wont works, since product type needs RestSharp course source code
        // var product = data?.Deserialize<Product>(new JsonSerializerOptions
        // {
        //     PropertyNameCaseInsensitive = true
        // });
        //
        //
        // using (new AssertionScope())
        // {
        //     response.Status.Should().Be(201);
        //     product?.Name.Should().Be("Keyboards");
        //     product?.ProductId.Should().Be(2);
        // }
    }

    private async Task<string?> GetToken()
    {
        var response = await _playwrightDriver.ApiRequestContext?.PostAsync("api/Authenticate/Login",
            new APIRequestContextOptions
            {
                DataObject = new
                {
                    UserName = "KK",
                    Password = "123456"
                }
            })!;

        var jsonString = await response.JsonAsync();

        return jsonString?.Deserialize<Authenticate>(new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })?.Token;
    }


    private record Authenticate(string Token)
    {
    }
}