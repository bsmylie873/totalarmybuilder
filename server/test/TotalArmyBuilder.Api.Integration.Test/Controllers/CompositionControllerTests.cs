using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using TotalArmyBuilder.Api.Integration.Test.Base;
using TotalArmyBuilder.Api.Integration.Test.TestUtilities;
using TotalArmyBuilder.Api.ViewModels.Compositions;
using TotalArmyBuilder.Api.ViewModels.Units;
using TotalArmyBuilder.Dal.Models;
using Xunit.Abstractions;

namespace TotalArmyBuilder.Api.Integration.Test.Controllers;

[Collection("Integration")]
public class CompositionControllerTests
{
    private readonly HttpClient _httpClient;
    private readonly ITestOutputHelper _testOutputHelper;

    public CompositionControllerTests(ITestOutputHelper testOutputHelper, IntegrationClassFixture integrationFixture)
    {
        _testOutputHelper = testOutputHelper;
        _httpClient = integrationFixture.Host.CreateClient();
    }

    [Fact]
    public async Task GetAllCompositions_WhenCompositionsPresent_ReturnsOk()
    {
        var response = await _httpClient.GetAsync("compositions/");
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

        var result = value.VerifyDeSerialize<CompositionDetailViewModel>();

        result.Id.Should().Be(1);
        result.Name.Should().Be("composition1");
        result.BattleType.Should().Be(1);
        result.FactionId.Should().Be(1);
        result.AvatarId.Should().Be(1);
        result.Wins.Should().Be(1);
        result.Losses.Should().Be(1);
    }
    
    [Fact]
    public async Task GetACompositionById_WhenCompositionNotPresent_ThrowException()
    {
        const int id = 6426;
        var response = await _httpClient.GetAsync($"compositions/{id}");
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task GetCompositionUnitsById_WhenCompositionUnits_Present_ReturnsOk()
    {
        const int id = 1;
        var response = await _httpClient.GetAsync($"compositions/{id}/units/");
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var value = await response.Content.ReadAsStringAsync();
        var result = value.VerifyDeSerialize<IList<UnitDetailViewModel>>();

        result[0].Id.Should().Be(id);
        result[0].Name.Should().Be("unit1");
        result[0].Cost.Should().Be(1);
        result[0].AvatarId.Should().Be(1);
    }
    
    [Fact]
    public async Task GetACompositionUnitsById_WhenCompositionUnitsNotPresent_ThrowException()
    {
        const int id = 462;
        var response = await _httpClient.GetAsync($"compositions/{id}/units/");
        response.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }

    [Fact]
    public async Task CreateAComposition_WhenCompositionDetails_ValidAndPresent_ReturnsOk()
    {
        const string name = "name999";
        const int battleType = 1;
        const int factionId = 4;
        const int avatarId = 56;
        var dateCreated = DateTime.UtcNow;
        const int wins = 0;
        const int losses = 0;

        var accountComposition = new AccountComposition
        {
            Id = 100,
            AccountId = 1,
            CompositionId = 56
        };

        var unit1 = new Unit
        {
            Id = 231,
            Name = "name231"
        };

        var compositionUnit = new CompositionUnit
        {
            Id = 756,
            CompositionId = unit1.Id,
            UnitId = unit1.Id
        };

        var compositionUnits = new List<CompositionUnit> { compositionUnit };

        var accountCompositions = new List<AccountComposition> { accountComposition };

        var composition = new Composition
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

        var response = await _httpClient.PostAsJsonAsync("compositions/", composition);

        response.StatusCode.Should().Be(HttpStatusCode.Created);
    }
    
    [Fact]
    public async Task CreateAComposition_WhenCompositionDetails_NotValid_ThrowsException()
    {
        const string name = null;
        const int battleType = 1;
        const int factionId = 4;
        const int avatarId = 56;
        var dateCreated = DateTime.UtcNow;
        const int wins = 0;
        const int losses = 0;

        var accountComposition = new AccountComposition
        {
            Id = 100,
            AccountId = 1,
            CompositionId = 56
        };

        var unit1 = new Unit
        {
            Id = 231,
            Name = "name231"
        };

        var compositionUnit = new CompositionUnit
        {
            Id = 756,
            CompositionId = unit1.Id,
            UnitId = unit1.Id
        };

        var compositionUnits = new List<CompositionUnit> { compositionUnit };

        var accountCompositions = new List<AccountComposition> { accountComposition };

        var composition = new Composition
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

        var response = await _httpClient.PostAsJsonAsync("compositions/", composition);

        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

    [Fact]
    public async Task UpdateAComposition_WhenNewCompositionDetails_ValidAndPresent_ReturnsOk()
    {
        const int id = 2;
        const string newName = "new name";

        UpdateCompositionViewModel composition = new UpdateCompositionViewModel
        {
            Name = newName,
            BattleType = 1,
            FactionId = 2,
            AvatarId = 2,
            Wins = 2,
            Losses = 2
        };

        var response = await _httpClient.PatchAsJsonAsync($"compositions/{id}", composition);
        response.StatusCode.Should().Be(HttpStatusCode.NoContent);

        var getResponse = await _httpClient.GetAsync($"compositions/{id}");
        getResponse.StatusCode.Should().Be(HttpStatusCode.OK);

        var value = await getResponse.Content.ReadAsStringAsync();

        var result = value.VerifyDeSerialize<CompositionDetailViewModel>();

        result.Id.Should().Be(2);
        result.Name.Should().Be("new name");
        result.BattleType.Should().Be(1);
        result.FactionId.Should().Be(2);
        result.AvatarId.Should().Be(2);
        result.Wins.Should().Be(2);
        result.Losses.Should().Be(2);
    }

    [Fact]
    public async Task UpdateAComposition_WhenNewCompositionDetails_NotValid_ThrowsException()
    {
        const int id = 2;
        const string newName = "new name";

        UpdateCompositionViewModel composition = new UpdateCompositionViewModel
        {
            Name = newName,
            BattleType = 1,
            FactionId = 2,
            AvatarId = 2,
            Wins = 2,
            Losses = 2
        };

        var response = await _httpClient.PatchAsJsonAsync($"compositions/{id}", composition);
        response.StatusCode.Should().Be(HttpStatusCode.NoContent);

        var getresponse = await _httpClient.GetAsync($"compositions/{id}");
        getresponse.StatusCode.Should().Be(HttpStatusCode.OK);

        var value = await getresponse.Content.ReadAsStringAsync();

        var result = value.VerifyDeSerialize<CompositionDetailViewModel>();

        result.Id.Should().Be(2);
        result.Name.Should().Be("new name");
        result.BattleType.Should().Be(1);
        result.FactionId.Should().Be(2);
        result.AvatarId.Should().Be(2);
        result.Wins.Should().Be(2);
        result.Losses.Should().Be(2);
    }
    
    [Fact]
    public async Task DeleteAComposition_WhenCompositionFound_ThenDeleted_ReturnsOk()
    {
        const int id = 2;

        var response = await _httpClient.DeleteAsync($"compositions/{id}");
        response.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}