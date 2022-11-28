using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using Newtonsoft.Json;
using TotalArmyBuilder.Api.Integration.Test.Base;
using TotalArmyBuilder.Api.Integration.Test.TestUtilities;
using TotalArmyBuilder.Api.ViewModels.Accounts;
using TotalArmyBuilder.Api.ViewModels.Compositions;
using TotalArmyBuilder.Api.ViewModels.Units;
using TotalArmyBuilder.Dal.Models;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace TotalArmyBuilder.Api.Integration.Test.Controllers;

[Collection("Integration")]
public class CompositionControllerTests
{
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly HttpClient _httpClient;
    
    public CompositionControllerTests(ITestOutputHelper testOutputHelper, IntegrationClassFixture integrationFixture)
    {
        _testOutputHelper = testOutputHelper;
        _httpClient = integrationFixture.Host.CreateClient();
    } 
    
    [Fact]
    public async Task GetAllCompositions_WhenCompositionsPresent_ReturnsOk()
    {
        var response = await _httpClient.GetAsync($"compositions/");
        response.StatusCode.Should().Be(HttpStatusCode.OK);
            
        var value = await response.Content.ReadAsStringAsync();
        _testOutputHelper.WriteLine(value.VerifyDeSerialization<CompositionViewModel[]>());
    }
    
    [Fact]
    public async Task GetACompositionById_WhenCompositionPresent_ReturnsOk()
    {
        const int id = 1;
        var response = await _httpClient.GetAsync($"compositions/{id}");
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var value = await response.Content.ReadAsStringAsync();
        //_testOutputHelper.WriteLine(value.VerifyDeSerialization<AccountDetailViewModel>());
        
        Assert.Contains("1", value);
        Assert.Contains("name", value);
    }
    
    [Fact]
    public async Task GetCompositionUnitsById_WhenCompositionUnits_Present_ReturnsOk()
    {
        const int id = 1;
        var response = await _httpClient.GetAsync($"compositions/{id}/units/");
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var value = await response.Content.ReadAsStringAsync();
        _testOutputHelper.WriteLine(value.VerifyDeSerialization<UnitViewModel[]>());
        
        Assert.Contains("1", value);
        Assert.Contains("name", value);
    }
    
    [Fact]
    public async Task CreateAComposition_WhenCompositionDetails_ValidAndPresent_ReturnsOk()
    {
        const string name = "name999";
        const int battleType = 1;
        const int factionId = 1;
        const int avatarId = 1;
        DateTime dateCreated = DateTime.MaxValue;
        const int wins = 999;
        const int losses = 1;

        AccountComposition accountComposition = new AccountComposition
        {
            Id = 100,
            AccountId = 1,
            CompositionId = 56
        };

        Unit unit1 = new Unit
        {
            Id = 231,
            Name = "name231"
        };

        CompositionUnit compositionUnit = new CompositionUnit
        {
            Id = 756,
            CompositionId = unit1.Id,
            UnitId = unit1.Id
        };

        var compositionUnits = new List<CompositionUnit> { compositionUnit };

        var accountCompositions = new List<AccountComposition> { accountComposition };

        Composition composition = new Composition
        {
            Name = name,
            BattleType = battleType,
            FactionId = factionId,
            AvatarId = avatarId,
            DateCreated = dateCreated,
            Wins = wins,
            Losses = losses,
            AccountCompositions = accountCompositions,
            CompositionUnits = compositionUnits
        };
        
        
        var response = await _httpClient.PostAsJsonAsync($"compositions/", composition);
        response.StatusCode.Should().Be(HttpStatusCode.Created);
    }
    
    [Fact]
    public async Task UpdateAComposition_WhenNewCompositionDetails_ValidAndPresent_ReturnsOk()
    {
        const int id = 1;
        const string newName = "new name";

        Composition composition = new Composition
        {
            Name = newName
        };

        var compositionJson = JsonConvert.SerializeObject(composition);

        var stringContent = new StringContent(compositionJson);
        var response = await _httpClient.PatchAsync($"compositions/{id}", stringContent);
        response.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
    
    [Fact]
    public async Task DeleteAComposition_WhenCompositionFound_ThenDeleted_ReturnsOk()
    {
        const int id = 2;
        
        var response = await _httpClient.DeleteAsync($"compositions/{id}");
        response.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}