using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using TotalArmyBuilder.Api.Integration.Test.Base;
using TotalArmyBuilder.Api.Integration.Test.Models;
using TotalArmyBuilder.Api.Integration.Test.TestUtilities;
using TotalArmyBuilder.Api.ViewModels.Accounts;
using TotalArmyBuilder.Api.ViewModels.Compositions;
using Xunit.Abstractions;

namespace TotalArmyBuilder.Api.Integration.Test.Controllers;

[Collection("Integration")]
public class AccountControllerTests
{
    private readonly HttpClient _httpClient;
    private readonly ITestOutputHelper _testOutputHelper;

    public AccountControllerTests(ITestOutputHelper testOutputHelper, IntegrationClassFixture integrationFixture)
    {
        var opt = new WebApplicationFactoryClientOptions();
        opt.BaseAddress = new Uri("https://localhost");

        _testOutputHelper = testOutputHelper;
        _httpClient = integrationFixture.Host.CreateClient(opt);
    }

    [Fact]
    public async Task GetAllAccounts_WhenAccountsPresent_ReturnsOk()
    {
        var response = await _httpClient.GetAsync("/accounts/");
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var value = await response.Content.ReadAsStringAsync();
        _testOutputHelper.WriteLine(value.VerifyDeSerialization<AccountViewModel[]>());
    }
    

    [Fact]
    public async Task GetAnAccountById_WhenAccountPresent_ReturnsOk()
    {
        const int id = 2;
        var response = await _httpClient.GetAsync($"/accounts/{id}");
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var value = await response.Content.ReadAsStringAsync();
        var result = value.VerifyDeSerialize<AccountDetailViewModel>();

        result.Id.Should().Be(id);
        result.Username.Should().Be("username2");
        result.Email.Should().Be("email2@email.com");
    }
    
    [Fact]
    public async Task GetAnAccountById_AccountNotPresent_ThrowException()
    {
        const int id = 20;
        var response = await _httpClient.GetAsync($"/accounts/{id}");
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task GetAnAccountCompositionsById_WhenAccountCompositions_Present_ReturnsOk()
    {
        const int id = 1;
        var response = await _httpClient.GetAsync($"/accounts/{id}/compositions/");
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var value = await response.Content.ReadAsStringAsync();
        var result = value.VerifyDeSerialize<IList<CompositionViewModel>>();

        result[0].Name.Should().Be("composition1");
        result[0].BattleType.Should().Be("Land Battles");
        result[0].FactionId.Should().Be(1);
        result[0].AvatarId.Should().Be(1);
    }
    
    [Fact]
    public async Task GetAnAccountCompositionsById_WhenAccountCompositions_NotPresent_ThrowException()
    {
        const int id = 964;
        var response = await _httpClient.GetAsync($"/accounts/{id}/compositions/");
        response.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }

    [Fact]
    public async Task CreateAnAccount_WhenAccountDetails_ValidAndPresent_ReturnsOk()
    {
        const string username = "newUsername";
        const string email = "newemail@email.com";
        const string password = "newPassword";

        var account = new CreateAccountViewModel
        {
            Username = username,
            Email = email,
            Password = password
        };

        var response = await _httpClient.PostAsJsonAsync("accounts/", account);
        response.StatusCode.Should().Be(HttpStatusCode.Created);
    }
    
    [Fact]
    public async Task CreateAnAccount_WhenAccountDetails_NullParams_ThrowsException()
    {
        const string username = null;
        const string email = null;
        const string password = null;

        var account = new CreateAccountViewModel
        {
            Username = username,
            Email = email,
            Password = password
        };

        var response = await _httpClient.PostAsJsonAsync("accounts/", account);
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        
        var value = await response.Content.ReadAsStringAsync();
        
        var result = value.VerifyDeSerialize<ValidationModel>();
        result.Errors.CheckIfErrorPresent("Username", "The Username field is required.");
        result.Errors.CheckIfErrorPresent("Email", "The Email field is required.");
        result.Errors.CheckIfErrorPresent("Password", "The Password field is required.");

        _testOutputHelper.WriteLine(value);
    }
    
    [Fact]
    public async Task CreateAnAccount_WhenAccountDetails_InvalidParams_ThrowsException()
    {
        const string username = "null";
        const string email = "null";
        const string password = "null";

        var account = new CreateAccountViewModel
        {
            Username = username,
            Email = email,
            Password = password
        };

        var response = await _httpClient.PostAsJsonAsync("accounts/", account);
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        
        var value = await response.Content.ReadAsStringAsync();
        
        var result = value.VerifyDeSerialize<ValidationModel>();
        result.Errors.CheckIfErrorPresent("Username", "'Username' must be between 5 and 100 characters. You entered 4 characters.");
        result.Errors.CheckIfErrorPresent("Email", "'Email' is not a valid email address.");
        result.Errors.CheckIfErrorPresent("Password", "'Password' must be between 8 and 50 characters. You entered 4 characters.");

        _testOutputHelper.WriteLine(value);
    }


    [Fact]
    public async Task UpdateAnAccount_WhenNewAccountDetails_ValidAndPresent_ReturnsOk()
    {
        const int id = 2;
        const string newUsername = "newUsername";
        const string newEmail = "newEmail@newEmail.com";

        UpdateAccountViewModel account = new UpdateAccountViewModel
        {
            Username = newUsername,
            Email = newEmail
        };

        var response = await _httpClient.PatchAsJsonAsync($"accounts/{id}", account);
        response.StatusCode.Should().Be(HttpStatusCode.NoContent);


        var getResponse = await _httpClient.GetAsync($"/accounts/{id}");
        getResponse.StatusCode.Should().Be(HttpStatusCode.OK);

        var value = await getResponse.Content.ReadAsStringAsync();
        var result = value.VerifyDeSerialize<AccountDetailViewModel>();

        result.Id.Should().Be(id);
        result.Username.Should().Be("newUsername");
        result.Email.Should().Be("newEmail@newEmail.com");
    }
    
    [Fact]
    public async Task UpdateAnAccount_WhenNewAccountDetails_NullParams_ReturnsOk()
    {
        const int id = 2;
        const string newUsername = null;
        const string newEmail = null;

        UpdateAccountViewModel account = new UpdateAccountViewModel
        {
            Username = newUsername,
            Email = newEmail
        };

        var response = await _httpClient.PatchAsJsonAsync($"accounts/{id}", account);
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        
        var value = await response.Content.ReadAsStringAsync();
        
        var result = value.VerifyDeSerialize<ValidationModel>();
        result.Errors.CheckIfErrorPresent("NoValue", "At least one parameter required.");

        _testOutputHelper.WriteLine(value);
    }
    
    [Fact]
    public async Task UpdateAnAccount_WhenNewAccountDetails_InvalidParams_ReturnsOk()
    {
        const int id = 2;
        const string newUsername = "null";
        const string newEmail = "null";

        UpdateAccountViewModel account = new UpdateAccountViewModel
        {
            Username = newUsername,
            Email = newEmail
        };

        var response = await _httpClient.PatchAsJsonAsync($"accounts/{id}", account);
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        
        var value = await response.Content.ReadAsStringAsync();
        
        var result = value.VerifyDeSerialize<ValidationModel>();
        result.Errors.CheckIfErrorPresent("Username", "'Username' must be between 5 and 100 characters. You entered 4 characters.");
        result.Errors.CheckIfErrorPresent("Email", "'Email' is not a valid email address.");

        _testOutputHelper.WriteLine(value);
    }
    
    [Fact]
    public async Task UpdateAnAccount_WhenId_IsInvalid_ReturnsOk()
    {
        const int id = 513;
        const string newUsername = "username";
        const string newEmail = "email@email.com";

        UpdateAccountViewModel account = new UpdateAccountViewModel
        {
            Username = newUsername,
            Email = newEmail
        };

        var response = await _httpClient.PatchAsJsonAsync($"accounts/{id}", account);
        response.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
    }

    [Fact]
    public async Task DeleteAnAccount_WhenAccountFound_ThenDeleted_ReturnsOk()
    {
        const int id = 5;

        var response = await _httpClient.DeleteAsync($"accounts/{id}");
        response.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
    
    [Fact]
    public async Task DeleteAnAccount_WhenAccountNotFound_ThrowsException()
    {
        const int id = 315;

        var response = await _httpClient.DeleteAsync($"accounts/{id}");
        response.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
    }
}