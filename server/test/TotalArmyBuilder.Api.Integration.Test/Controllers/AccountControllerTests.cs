using System.Net;
using System.Net.Http.Json;
using System.Text;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Namotion.Reflection;
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
        WebApplicationFactoryClientOptions opt = new WebApplicationFactoryClientOptions();
        opt.BaseAddress = new Uri("https://localhost");
        
        _testOutputHelper = testOutputHelper;
        _httpClient = integrationFixture.Host.CreateClient(opt);
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
        const int id = 2;
        var response = await _httpClient.GetAsync($"/accounts/{id}");
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var value = await response.Content.ReadAsStringAsync();
        var result = value.VerifyDeSerialize<AccountDetailViewModel>();

        result.Id.Should().Be(id);
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
        const string username = "newUsername";
        const string email = "newemail@email.com";
        const string password = "newPassword";

        Account account = new Account
        {
            Username = username,
            Email = email,
            Password = password
        };

        var response = await _httpClient.PostAsJsonAsync($"accounts/", account);
        response.StatusCode.Should().Be(HttpStatusCode.Created);
    }
    
    [Fact]
    public async Task UpdateAnAccount_WhenNewAccountDetails_ValidAndPresent_ReturnsOk()
    {
        const int id = 2;
        const string newUsername = "new username";

        UpdateAccountViewModel account = new UpdateAccountViewModel
        {
            Username = newUsername
        };

        var response = await _httpClient.PatchAsJsonAsync($"accounts/{id}", account);
        response.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
    
    [Fact]
    public async Task DeleteAnAccount_WhenAccountFound_ThenDeleted_ReturnsOk()
    {
        const int id = 2;
        
        var response = await _httpClient.DeleteAsync($"accounts/{id}");
        response.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}