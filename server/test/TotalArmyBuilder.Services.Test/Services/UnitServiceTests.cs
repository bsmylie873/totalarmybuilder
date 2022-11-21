using AutoFixture;
using AutoFixture.Xunit2;
using AutoMapper;
using FluentAssertions;
using NSubstitute;
using TotalArmyBuilder.Dal.Interfaces;
using TotalArmyBuilder.Dal.Models;
using TotalArmyBuilder.Service.DTOs;
using TotalArmyBuilder.Service.Interfaces;
using TotalArmyBuilder.Service.Profiles;
using TotalArmyBuilder.Service.Services;
using TotalArmyBuilder.Services.Test.Customisations;


namespace TotalArmyBuilder.Services.Test.Services;

public class UnitServiceTests
{
    private readonly ITotalArmyDatabase _database;
    private readonly IMapper _mapper;
    private readonly IFixture _fixture;
    
    private IUnitService RetrieveService()
    {
        return new UnitService(_database, _mapper);
    }

    private static IMapper GetMapper()
    {
        var config = new MapperConfiguration(cfg => {
            cfg.AddProfile<UnitProfile>();
        });

        return new Mapper(config);
    }

    public UnitServiceTests()
    {
        _database = Substitute.For<ITotalArmyDatabase>();
        _mapper = GetMapper();
        _fixture = new Fixture();
    }
    
    private void HandleFixtureRecursion()
    {
        _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
            .ForEach(b => _fixture.Behaviors.Remove(b));
        _fixture.Behaviors.Add(new OmitOnRecursionBehavior(1));
    }

    [Fact]
    public void GetUnitById_WhenUnitExist_ReturnsUnit()
    {
        // Arrange
        _fixture.Customize(new UnitCustomisation("test"));
        var unitList = _fixture.CreateMany<Unit>(5);
        _database.Get<Unit>().Returns(unitList.AsQueryable());

        var service = RetrieveService();

        // Act
        var result = service.GetUnitById(unitList.First().Id);

        // Assert
        result.Should().BeEquivalentTo(unitList.First(), options => options.ExcludingMissingMembers());
    }
    
    [Fact]
    public void GetUnits_WhenUnitsExist_ReturnsUnits()
    {
        _fixture.Customize(new UnitCustomisation("test"));
        var unitList = _fixture.CreateMany<Unit>(5);
        _database.Get<Unit>().Returns(unitList.AsQueryable());

        var service = RetrieveService();

        // Act
        var result = service.GetUnits();

        // Assert
        result.Should().BeEquivalentTo(unitList, options => options.ExcludingMissingMembers());
    }
    
    [Fact]
    public void GetFactionUnits_WhenUnitsExist_ReturnsUnits()
    {
        // Arrange
        HandleFixtureRecursion();
        _fixture.Customize(new UnitCustomisation("test"));
        var unitList = _fixture.CreateMany<Unit>(5);
        _database.Get<Unit>().Returns(unitList.AsQueryable());
        
        _fixture.Customize(new FactionCustomisation("test"));
        var factionList = _fixture.CreateMany<Faction>(5);
        _database.Get<Faction>().Returns(factionList.AsQueryable());

        var service = RetrieveService();

        // Act
        var result = service.GetUnitFactions(unitList.First().Id);

        // Assert
        result.Should().BeEquivalentTo(factionList, options => options.ExcludingMissingMembers());
    }
    
    [Fact]
    public void GetUnitLords_WhenUnitsExist_ReturnsUnits()
    {
        // Arrange
        HandleFixtureRecursion();
        _fixture.Customize(new UnitCustomisation("test"));
        var unitList = _fixture.CreateMany<Unit>(5);
        _database.Get<Unit>().Returns(unitList.AsQueryable());
        
        var lord = _fixture
            .Build<LordUnit>()
            .With(x => x.Id, 1)
            .With(x => x.UnitId, unitList.First().Id);

        var service = RetrieveService();

        // Act
        var result = service.GetUnitLords(unitList.First().Id);

        // Assert
        result.Should().BeEquivalentTo(unitList, options => options.ExcludingMissingMembers());
    }
    
    [Fact]
    public void GetUnitHeroes_WhenUnitsExist_ReturnsUnits()
    {
        // Arrange
        HandleFixtureRecursion();
        _fixture.Customize(new UnitCustomisation("test"));
        var unitList = _fixture.CreateMany<Unit>(5);
        _database.Get<Unit>().Returns(unitList.AsQueryable());
        
        var hero = _fixture
            .Build<HeroUnit>()
            .With(x => x.Id, 1)
            .With(x => x.UnitId, unitList.First().Id);

        var service = RetrieveService();

        // Act
        var result = service.GetUnitHeroes(unitList.First().Id);

        // Assert
        result.Should().BeEquivalentTo(unitList, options => options.ExcludingMissingMembers());
    }
}