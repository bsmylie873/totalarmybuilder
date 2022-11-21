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

public class FactionServiceTests
{
    private readonly ITotalArmyDatabase _database;
    private readonly IMapper _mapper;
    private readonly IFixture _fixture;
    
    
    private IFactionService RetrieveService()
    {
        return new FactionService(_database, _mapper);
    }

    private static IMapper GetMapper()
    {
        var config = new MapperConfiguration(cfg => {
            cfg.AddProfile<FactionProfile>();
        });

        return new Mapper(config);
    }
    
    private void HandleFixtureRecursion()
    {
        _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
            .ForEach(b => _fixture.Behaviors.Remove(b));
        _fixture.Behaviors.Add(new OmitOnRecursionBehavior(1));
    }

    public FactionServiceTests()
    {
        _database = Substitute.For<ITotalArmyDatabase>();
        _mapper = GetMapper();
        _fixture = new Fixture();
    }

    [Fact]
    public void GetFactionById_WhenFactionExist_ReturnsFaction()
    {
        // Arrange
        _fixture.Customize(new FactionCustomisation("test"));
        var factionList = _fixture.CreateMany<Faction>(5);
        _database.Get<Faction>().Returns(factionList.AsQueryable());

        var service = RetrieveService();

        // Act
        var result = service.GetFactionById(factionList.First().Id);

        // Assert
        result.Should().BeEquivalentTo(factionList.First(), options => options.ExcludingMissingMembers());
    }
    
    [Fact]
    public void GetFactions_WhenFactionsExist_ReturnsFactions()
    {
        _fixture.Customize(new FactionCustomisation("test"));
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
        HandleFixtureRecursion();
        _fixture.Customize(new FactionCustomisation("test"));
        var factionList = _fixture.CreateMany<Faction>(5);
        _database.Get<Faction>().Returns(factionList.AsQueryable());
        
        
        _fixture.Customize(new UnitCustomisation("test"));
        var unitList = _fixture.CreateMany<Unit>(5);
        _database.Get<Unit>().Returns(unitList.AsQueryable());
        
        var service = RetrieveService();
        

        // Act
        var result = service.GetFactionUnits(factionList.First().Id);

        // Assert
        result.Should().BeEquivalentTo(unitList, options => options.ExcludingMissingMembers());
    }
}