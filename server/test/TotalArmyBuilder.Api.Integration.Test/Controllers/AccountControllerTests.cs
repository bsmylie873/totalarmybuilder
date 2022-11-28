using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using Newtonsoft.Json;
using TotalArmyBuilder.Api.Integration.Test.Base;
using TotalArmyBuilder.Api.Integration.Test.TestUtilities;
using TotalArmyBuilder.Api.ViewModels.Accounts;
using TotalArmyBuilder.Api.ViewModels.Compositions;
using TotalArmyBuilder.Dal.Models;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace TotalArmyBuilder.Api.Integration.Test.Controllers;

[Collection("Integration")]
public class AccountControllerTests
{
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly HttpClient _httpClient;
    
    public AccountControllerTests(ITestOutputHelper testOutputHelper, IntegrationClassFixture integrationFixture)
    {
        _testOutputHelper = testOutputHelper;
        _httpClient = integrationFixture.Host.CreateClient();
    } 
    
    [Fact]
    public async Task GetAllAccounts_WhenAccountsPresent_ReturnsOk()
    {
        var response = await _httpClient.GetAsync($"/accounts/");
        response.StatusCode.Should().Be(HttpStatusCode.OK);
            
        var value = await response.Content.ReadAsStringAsync();
        _testOutputHelper.WriteLine(value.VerifyDeSerialization<AccountViewModel[]>());
    }
    
    [Fact]
    public async Task GetAnAccountById_WhenAccountPresent_ReturnsOk()
    {
        const int id = 1;
        var response = await _httpClient.GetAsync($"/accounts/{id}");
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var value = await response.Content.ReadAsStringAsync();
        //_testOutputHelper.WriteLine(value.VerifyDeSerialization<AccountDetailViewModel>());
        
        Assert.Contains("1", value);
        Assert.Contains("username", value);
        Assert.Contains("email", value);
    }
    
    [Fact]
    public async Task GetAnAccountCompositionsById_WhenAccountCompositions_Present_ReturnsOk()
    {
        const int id = 1;
        var response = await _httpClient.GetAsync($"/accounts/{id}/compositions/");
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var value = await response.Content.ReadAsStringAsync();
        _testOutputHelper.WriteLine(value.VerifyDeSerialization<CompositionViewModel[]>());
        
        Assert.Contains("1", value);
        Assert.Contains("name", value);
    }
    
    [Fact]
    public async Task CreateAnAccount_WhenAccountDetails_ValidAndPresent_ReturnsOk()
    {
        const int id = 2;
        const string username = "username2";
        const string email = "email2@email.com";
        const string password = "password2";

        Account account = new Account
        {
            Id = id,
            Username = username,
            Email = email,
            Password = password
        };

        var accountJson = JsonConvert.SerializeObject(account);

        var stringContent = new StringContent(accountJson);
        var response = await _httpClient.PostAsync($"/accounts/", stringContent);
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
    
    [Fact]
    public async Task UpdateAnAccount_WhenNewAccountDetails_ValidAndPresent_ReturnsOk()
    {
        const int id = 1;
        const string newUsername = "new username";

        Account account = new Account
        {
            Username = newUsername
        };

        var accountJson = JsonConvert.SerializeObject(account);

        var stringContent = new StringContent(accountJson);
        var response = await _httpClient.PatchAsync($"/accounts/{id}", stringContent);
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
    
    [Fact]
    public async Task DeleteAnAccount_WhenAccountFound_ThenDeleted_ReturnsOk()
    {
        const int id = 1;
        
        var response = await _httpClient.DeleteAsync($"/accounts/{id}");
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}