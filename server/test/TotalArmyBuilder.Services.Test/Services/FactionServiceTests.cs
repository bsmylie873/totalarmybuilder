using AutoFixture;
using AutoMapper;
using FluentAssertions;
using NSubstitute;
using TotalArmyBuilder.Dal.Interfaces;
using TotalArmyBuilder.Dal.Models;
using TotalArmyBuilder.Service.Interfaces;
using TotalArmyBuilder.Service.Profiles;
using TotalArmyBuilder.Service.Services;
using TotalArmyBuilder.Services.Test.Customisations;
using TotalArmyBuilder.Services.Test.Extensions;

namespace TotalArmyBuilder.Services.Test.Services;

public class FactionServiceTests
{
    private readonly ITotalArmyDatabase _database;
    private readonly IFixture _fixture;
    private readonly IMapper _mapper;

    public FactionServiceTests()
    {
        _database = Substitute.For<ITotalArmyDatabase>();
        _mapper = GetMapper();
        _fixture = new Fixture();

        _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
            .ForEach(b => _fixture.Behaviors.Remove(b));
        _fixture.Behaviors.Add(new OmitOnRecursionBehavior(1));
    }


    private IFactionService RetrieveService()
    {
        return new FactionService(_database, _mapper);
    }

    private static IMapper GetMapper()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<FactionProfile>();
            cfg.AddProfile<UnitProfile>();
        });

        return new Mapper(config);
    }

    [Fact]
    public void GetFactionById_WhenFactionExist_ReturnsFaction()
    {
        // Arrange
        const int factionId = 1;

        var factionIds = _fixture.MockWithOne(factionId);

        _fixture.Customize(new FactionCustomisation());
        var factionList = _fixture
            .Build<Faction>()
            .With(x => x.Id, factionIds.GetValue)
            .CreateMany(5)
            .AsQueryable();
        _database.Get<Faction>().Returns(factionList);

        var service = RetrieveService();

        // Act
        var result = service.GetFactionById(factionId);

        // Assert
        result.Should().BeEquivalentTo(factionList.First(), options => options.ExcludingMissingMembers());
    }

    [Fact]
    public void GetFactions_WhenFactionsExist_ReturnsFactions()
    {
        // Arrange
        _fixture.Customize(new FactionCustomisation());
        var factionList = _fixture.CreateMany<Faction>(5);
        _database.Get<Faction>().Returns(factionList.AsQueryable());

        var service = RetrieveService();

        // Act
        var result = service.GetFactions();

        // Assert
        result.Should().BeEquivalentTo(factionList, options => options.ExcludingMissingMembers());
    }

    [Fact]
    public void GetFactionUnits_WhenUnitsExist_ReturnsUnits()
    {
        // Arrange
        const int factionId = 1;
        const int unitId = 1;

        var factionIds = _fixture.MockWithOne(factionId);

        var unitFactionList = _fixture
            .Build<UnitFaction>()
            .With(x => x.FactionId, factionIds.GetValue)
            .With(x => x.UnitId, unitId)
            .CreateMany(5)
            .ToList();

        var unitList = _fixture
            .Build<Unit>()
            .With(x => x.Id, unitId)
            .With(x => x.UnitFactions, unitFactionList)
            .CreateMany(5)
            .AsQueryable();

        _database.Get<Unit>().Returns(unitList);

        var service = RetrieveService();

        // Act
        var result = service.GetFactionUnits(factionId);

        // Assert
        result.Should().BeEquivalentTo(unitList, options => options.ExcludingMissingMembers());
    }
}