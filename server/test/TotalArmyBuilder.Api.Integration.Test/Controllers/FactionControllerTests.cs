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
    private readonly HttpClient _httpClient;
    private readonly ITestOutputHelper _testOutputHelper;

    public FactionControllerTests(ITestOutputHelper testOutputHelper, IntegrationClassFixture integrationFixture)
    {
        _testOutputHelper = testOutputHelper;
        _httpClient = integrationFixture.Host.CreateClient();
    }

    [Fact]
    public async Task GetAllFactions_WhenFactionsPresent_ReturnsOk()
    {
        var response = await _httpClient.GetAsync("/factions/");
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var value = await response.Content.ReadAsStringAsync();
        _testOutputHelper.WriteLine(value.VerifyDeSerialization<FactionViewModel[]>());
    }

    [Fact]
    public async Task GetAFactionById_WhenFactionPresent_ReturnsOk()
    {
        const int id = 1;
        var response = await _httpClient.GetAsync($"/factions/{id}");
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var value = await response.Content.ReadAsStringAsync();
        var result = value.VerifyDeSerialize<FactionDetailViewModel>();

        result.Id.Should().Be(id);
        result.Name.Should().Be("faction1");
    }
    
    [Fact]
    public async Task GetAFactionById_WhenFactionNotPresent_ThrowsException()
    {
        const int id = 513;
        var response = await _httpClient.GetAsync($"/factions/{id}");
        response.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task GetFactionUnitsById_WhenFactionUnits_Present_ReturnsOk()
    {
        const int id = 1;
        var response = await _httpClient.GetAsync($"/factions/{id}/units/");
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var value = await response.Content.ReadAsStringAsync();
        var result = value.VerifyDeSerialize<IList<UnitDetailViewModel>>();

        result[0].Id.Should().Be(id);
        result[0].Name.Should().Be("unit1");
        result[0].Cost.Should().Be(1);
        result[0].AvatarId.Should().Be(1);
    }
    
    [Fact]
    public async Task GetFactionUnitsById_WhenFactionUnits_NotPresent_ThrowsException()
    {
        const int id = 513;
        var response = await _httpClient.GetAsync($"/factions/{id}/units/");
        response.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}