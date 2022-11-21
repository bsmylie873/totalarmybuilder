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


namespace TotalArmyBuilder.Services.Test.Services;

public class FactionServiceTests
{
    private readonly ITotalArmyDatabase _database;
    private readonly IMapper _mapper;
    
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

    public FactionServiceTests()
    {
        _database = Substitute.For<ITotalArmyDatabase>();
        _mapper = GetMapper();
    }

    [Fact]
    public void GetFactionById_WhenFactionExist_ReturnsFaction()
    {
        // Arrange
        const int id = 1;
        const int id2 = 2;

        var faction = new Faction
        {
            Id = id
        };
        
        var faction2 = new Faction
        {
            Id = id2
        };

        var factionList = new List<Faction>
        {
            faction, faction2
        };

        _database.Get<Faction>().Returns(factionList.AsQueryable());

        var service = RetrieveService();

        // Act
        var result = service.GetFactionById(id);

        // Assert
        result.Should().BeEquivalentTo(faction, options => options.ExcludingMissingMembers());
    }
    
    [Theory, AutoData]
    public void GetFactions_WhenFactionsExist_ReturnsFactions(string name)
    {
        // Arrange
        const int id = 1;
        const int id2 = 2;

        var faction = new Faction
        {
            Id = id,
            Name = name,
        };
        
        var faction2 = new Faction
        {
            Id = id2,
            Name = name,
        };

        var factionList = new List<Faction>
        {
            faction, faction2
        };

        _database.Get<Faction>().Returns(factionList.AsQueryable());

        var service = RetrieveService();

        // Act
        var result = service.GetFactions();

        // Assert
        result.Should().BeEquivalentTo(factionList, options => options.ExcludingMissingMembers());
    }
}