using System.Net;
using FluentAssertions;
using TotalArmyBuilder.Api.Integration.Test.Base;
using TotalArmyBuilder.Api.Integration.Test.TestUtilities;
using TotalArmyBuilder.Api.ViewModels.Factions;
using TotalArmyBuilder.Api.ViewModels.Units;
using Xunit.Abstractions;

namespace TotalArmyBuilder.Api.Integration.Test.Controllers;

[Collection("Integration")]
public class FactionControllerTests
{
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly HttpClient _httpClient;
    
    public FactionControllerTests(ITestOutputHelper testOutputHelper, IntegrationClassFixture integrationFixture)
    {
        _testOutputHelper = testOutputHelper;
        _httpClient = integrationFixture.Host.CreateClient();
    } 
    
    [Fact]
    public async Task GetAllFactions_WhenFactionsPresent_ReturnsOk()
    {
        var response = await _httpClient.GetAsync($"/factions/");
        response.StatusCode.Should().Be(HttpStatusCode.OK);
            
        var value = await response.Content.ReadAsStringAsync();
        _testOutputHelper.WriteLine(value.VerifyDeSerialization<FactionViewModel[]>());
    }
    
    [Fact]
    public async Task GetAFactionById_WhenCompositionPresent_ReturnsOk()
    {
        const int id = 1;
        var response = await _httpClient.GetAsync($"/factions/{id}");
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var value = await response.Content.ReadAsStringAsync();
        //_testOutputHelper.WriteLine(value.VerifyDeSerialization<AccountDetailViewModel>());
        
        Assert.Contains("1", value);
        Assert.Contains("name", value);
    }
    
    [Fact]
    public async Task GetFactionUnitsById_WhenFactionUnits_Present_ReturnsOk()
    {
        const int id = 1;
        var response = await _httpClient.GetAsync($"/factions/{id}/units/");
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var value = await response.Content.ReadAsStringAsync();
        _testOutputHelper.WriteLine(value.VerifyDeSerialization<UnitViewModel[]>());
        
        Assert.Contains("1", value);
        Assert.Contains("unit1", value);
    }
}