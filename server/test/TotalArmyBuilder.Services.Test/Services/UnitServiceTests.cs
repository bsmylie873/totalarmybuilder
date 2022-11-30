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

public class UnitServiceTests
{
    private readonly ITotalArmyDatabase _database;
    private readonly IFixture _fixture;
    private readonly IMapper _mapper;

    public UnitServiceTests()
    {
        _database = Substitute.For<ITotalArmyDatabase>();
        _mapper = GetMapper();
        _fixture = new Fixture();

        _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
            .ForEach(b => _fixture.Behaviors.Remove(b));
        _fixture.Behaviors.Add(new OmitOnRecursionBehavior(1));
    }

    private IUnitService RetrieveService()
    {
        return new UnitService(_database, _mapper);
    }

    private static IMapper GetMapper()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<UnitProfile>();
            cfg.AddProfile<FactionProfile>();
        });

        return new Mapper(config);
    }

    [Fact]
    public void GetUnitById_WhenUnitExist_ReturnsUnit()
    {
        // Arrange
        const int unitId = 1;

        var unitIds = _fixture.MockWithOne(unitId);

        _fixture.Customize(new UnitCustomisation());
        var unitList = _fixture
            .Build<Unit>()
            .With(x => x.Id, unitIds.GetValue)
            .CreateMany(5)
            .AsQueryable();
        _database.Get<Unit>().Returns(unitList);

        var service = RetrieveService();

        // Act
        var result = service.GetUnitById(unitId);

        // Assert
        result.Should().BeEquivalentTo(unitList.First(), options => options.ExcludingMissingMembers());
    }

    [Fact]
    public void GetUnits_WhenUnitsExist_ReturnsUnits()
    {
        _fixture.Customize(new UnitCustomisation());
        var unitList = _fixture.CreateMany<Unit>(5);
        _database.Get<Unit>().Returns(unitList.AsQueryable());

        var service = RetrieveService();

        // Act
        var result = service.GetUnits();

        // Assert
        result.Should().BeEquivalentTo(unitList, options => options.ExcludingMissingMembers());
    }

    [Fact]
    public void GetUnitFactions_WhenUnitsExist_ReturnsUnits()
    {
        // Arrange
        const int factionId = 1;
        const int unitId = 1;

        var unitIds = _fixture.MockWithOne(unitId);

        var unitFactionList = _fixture
            .Build<UnitFaction>()
            .With(x => x.FactionId, factionId)
            .With(x => x.UnitId, unitIds.GetValue)
            .CreateMany(5)
            .ToList();

        var factionList = _fixture
            .Build<Faction>()
            .With(x => x.Id, factionId)
            .With(x => x.UnitFactions, unitFactionList)
            .CreateMany(5)
            .AsQueryable();

        _database.Get<Faction>().Returns(factionList);

        var service = RetrieveService();

        // Act
        var result = service.GetUnitFactions(unitId);

        // Assert
        result.Should().BeEquivalentTo(factionList, options => options.ExcludingMissingMembers());
    }

    [Fact]
    public void GetUnitLords_WhenUnitsExist_ReturnsUnits()
    {
        // Arrange
        var unit = new Unit
        {
            Id = 1,
            Name = "LordUnit",
            Cost = 1000,
            AvatarId = 1
        };

        const int unitId = 1;

        var unitIds = _fixture.MockWithOne(unitId);

        _fixture.Customize(new UnitCustomisation());
        var unitList = _fixture
            .Build<Unit>()
            .With(x => x.Id, 1)
            .With(x => x.Name, "LordUnit")
            .With(x => x.Cost, 1000)
            .With(x => x.AvatarId, 1)
            .CreateMany(1)
            .AsQueryable();
        _database.Get<Unit>().Returns(unitList);

        var lordList = _fixture
            .Build<LordUnit>()
            .With(x => x.UnitId, 1)
            .With(x => x.Unit, unit)
            .CreateMany(1);
        _database.Get<LordUnit>().Returns(lordList.AsQueryable());

        var service = RetrieveService();

        // Act
        var result = service.GetUnitLords();

        // Assert
        result.Should().BeEquivalentTo(unitList, options => options.ExcludingMissingMembers());
    }

    [Fact]
    public void GetUnitHeroes_WhenUnitsExist_ReturnsUnits()
    {
        // Arrange
        var unit = new Unit
        {
            Id = 1,
            Name = "HeroUnit",
            Cost = 1000,
            AvatarId = 1
        };

        _fixture.Customize(new UnitCustomisation());
        var unitList = _fixture
            .Build<Unit>()
            .With(x => x.Id, 1)
            .With(x => x.Name, "HeroUnit")
            .With(x => x.Cost, 1000)
            .With(x => x.AvatarId, 1)
            .CreateMany(1);
        _database.Get<Unit>().Returns(unitList.AsQueryable());

        var heroList = _fixture
            .Build<HeroUnit>()
            .With(x => x.UnitId, 1)
            .With(x => x.Unit, unit)
            .CreateMany(1);
        _database.Get<HeroUnit>().Returns(heroList.AsQueryable());

        var service = RetrieveService();

        // Act
        var result = service.GetUnitHeroes();

        // Assert
        result.Should().BeEquivalentTo(unitList, options => options.ExcludingMissingMembers());
    }
}