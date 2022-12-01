using System.Net;
using FluentAssertions;
using TotalArmyBuilder.Api.Integration.Test.Base;
using TotalArmyBuilder.Api.Integration.Test.TestUtilities;
using TotalArmyBuilder.Api.ViewModels.Factions;
using TotalArmyBuilder.Api.ViewModels.Units;
using Xunit.Abstractions;

namespace TotalArmyBuilder.Api.Integration.Test.Controllers;

[Collection("Integration")]
public class UnitControllerTests
{
    private readonly HttpClient _httpClient;
    private readonly ITestOutputHelper _testOutputHelper;

    public UnitControllerTests(ITestOutputHelper testOutputHelper, IntegrationClassFixture integrationFixture)
    {
        _testOutputHelper = testOutputHelper;
        _httpClient = integrationFixture.Host.CreateClient();
    }

    [Fact]
    public async Task GetAllUnits_WhenUnitsPresent_ReturnsOk()
    {
        var response = await _httpClient.GetAsync("/units/");
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var value = await response.Content.ReadAsStringAsync();
        _testOutputHelper.WriteLine(value.VerifyDeSerialization<UnitViewModel[]>());
    }

    [Fact]
    public async Task GetAUnitById_WhenUnitPresent_ReturnsOk()
    {
        const int id = 1;
        var response = await _httpClient.GetAsync($"/units/{id}");
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var value = await response.Content.ReadAsStringAsync();
        var result = value.VerifyDeSerialize<UnitDetailViewModel>();

        result.Id.Should().Be(id);
        result.Name.Should().Be("unit1");
        result.Cost.Should().Be(1);
        result.AvatarId.Should().Be(1);
    }
    
    [Fact]
    public async Task GetAUnitById_WhenUnitNotPresent_ThrowsException()
    {
        const int id = 612;
        var response = await _httpClient.GetAsync($"/units/{id}");
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }
    
    [Fact]
    public async Task GetUnitFactionsById_WhenUnitFactions_Present_ReturnsOk()
    {
        const int id = 1;
        var response = await _httpClient.GetAsync($"/units/{id}/factions/");
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var value = await response.Content.ReadAsStringAsync();
        var result = value.VerifyDeSerialize<IList<FactionDetailViewModel>>();

        result[0].Id.Should().Be(id);
        result[0].Name.Should().Be("faction1");
    }
    
    [Fact]
    public async Task GetUnitFactionsById_WhenUnitFactions_NotPresent_ThrowsException()
    {
        const int id = 612;
        var response = await _httpClient.GetAsync($"/units/{id}/factions/");
        response.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }

    [Fact]
    public async Task GetUnitLords_WhenUnitLords_Present_ReturnsOk()
    {
        const int id = 1;
        var response = await _httpClient.GetAsync("/units/lords/");
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var value = await response.Content.ReadAsStringAsync();
        var result = value.VerifyDeSerialize<IList<UnitDetailViewModel>>();

        result[0].Id.Should().Be(id);
        result[0].Name.Should().Be("unit1");
        result[0].Cost.Should().Be(1);
        result[0].AvatarId.Should().Be(1);
    }

    [Fact]
    public async Task GetUnitHeroes_WhenUnitHeroes_Present_ReturnsOk()
    {
        const int id = 2;
        var response = await _httpClient.GetAsync("/units/heroes/");
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var value = await response.Content.ReadAsStringAsync();
        var result = value.VerifyDeSerialize<IList<UnitDetailViewModel>>();

        result[0].Id.Should().Be(id);
        result[0].Name.Should().Be("unit2");
        result[0].Cost.Should().Be(2);
        result[0].AvatarId.Should().Be(2);
    }
}