using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using Newtonsoft.Json;
using TotalArmyBuilder.Api.Integration.Test.Base;
using TotalArmyBuilder.Api.Integration.Test.TestUtilities;
using TotalArmyBuilder.Api.ViewModels.Accounts;
using TotalArmyBuilder.Api.ViewModels.Compositions;
using TotalArmyBuilder.Api.ViewModels.Factions;
using TotalArmyBuilder.Api.ViewModels.Units;
using TotalArmyBuilder.Dal.Models;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace TotalArmyBuilder.Api.Integration.Test.Controllers;

[Collection("Integration")]
public class UnitControllerTests
{
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly HttpClient _httpClient;
    
    public UnitControllerTests(ITestOutputHelper testOutputHelper, IntegrationClassFixture integrationFixture)
    {
        _testOutputHelper = testOutputHelper;
        _httpClient = integrationFixture.Host.CreateClient();
    } 
    
    [Fact]
    public async Task GetAllUnits_WhenUnitsPresent_ReturnsOk()
    {
        var response = await _httpClient.GetAsync($"/units/");
        response.StatusCode.Should().Be(HttpStatusCode.OK);
            
        var value = await response.Content.ReadAsStringAsync();
        _testOutputHelper.WriteLine(value.VerifyDeSerialization<UnitViewModel[]>());
    }
    
    [Fact]
    public async Task GetAUnitById_WhenCompositionPresent_ReturnsOk()
    {
        const int id = 1;
        var response = await _httpClient.GetAsync($"/units/{id}");
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var value = await response.Content.ReadAsStringAsync();
        //_testOutputHelper.WriteLine(value.VerifyDeSerialization<AccountDetailViewModel>());
        
        Assert.Contains("1", value);
        Assert.Contains("name", value);
    }
    
    [Fact]
    public async Task GetUnitFactionsById_WhenUnitFactions_Present_ReturnsOk()
    {
        const int id = 1;
        var response = await _httpClient.GetAsync($"/units/{id}/factions/");
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var value = await response.Content.ReadAsStringAsync();
        _testOutputHelper.WriteLine(value.VerifyDeSerialization<FactionViewModel[]>());
        
        Assert.Contains("1", value);
        Assert.Contains("name", value);
    }
    
    [Fact]
    public async Task GetUnitLords_WhenUnitLords_Present_ReturnsOk()
    {
        const int id = 1;
        var response = await _httpClient.GetAsync($"/units/lords/");
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var value = await response.Content.ReadAsStringAsync();
        _testOutputHelper.WriteLine(value.VerifyDeSerialization<UnitViewModel[]>());
        
        Assert.Contains("1", value);
        Assert.Contains("unit1", value);
    }
    
    [Fact]
    public async Task GetUnitHeroes_WhenUnitHeroes_Present_ReturnsOk()
    {
        const int id = 1;
        var response = await _httpClient.GetAsync($"/units/heroes/");
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var value = await response.Content.ReadAsStringAsync();
        _testOutputHelper.WriteLine(value.VerifyDeSerialization<UnitViewModel[]>());
        
        Assert.Contains("2", value);
        Assert.Contains("unit2", value);
    }
}