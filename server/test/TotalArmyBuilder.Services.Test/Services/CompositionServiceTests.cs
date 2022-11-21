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

public class CompositionServiceTests
{
    private readonly ITotalArmyDatabase _database;
    private readonly IMapper _mapper;
    
    private ICompositionService RetrieveService()
    {
        return new CompositionService(_database, _mapper);
    }

    private static IMapper GetMapper()
    {
        var config = new MapperConfiguration(cfg => {
            cfg.AddProfile<CompositionProfile>();
        });

        return new Mapper(config);
    }

    public CompositionServiceTests()
    {
        _database = Substitute.For<ITotalArmyDatabase>();
        _mapper = GetMapper();
    }

    [Fact]
    public void GetCompositionById_WhenCompositionExist_ReturnsComposition()
    {
        // Arrange
        const int id = 1;
        const int id2 = 2;

        var composition = new Composition
        {
            Id = id
        };
        
        var composition2 = new Composition
        {
            Id = id2
        };

        var compositionList = new List<Composition>
        {
            composition, composition2
        };

        _database.Get<Composition>().Returns(compositionList.AsQueryable());

        var service = RetrieveService();

        // Act
        var result = service.GetCompositionById(id);

        // Assert
        result.Should().BeEquivalentTo(composition, options => options.ExcludingMissingMembers());
    }
    
    [Theory, AutoData]
    public void GetCompositions_WhenCompositionsExist_ReturnsCompositions(string name, int battleType, int factionId)
    {
        // Arrange
        const int id = 1;
        const int id2 = 2;

        var composition = new Composition
        {
            Id = id,
            Name = name,
            BattleType = battleType,
            FactionId = factionId,
        };
        
        var composition2 = new Composition
        {
            Id = id2,
            Name = name,
            BattleType = battleType,
            FactionId = factionId,
        };

        var compositionList = new List<Composition>
        {
            composition, composition2
        };

        _database.Get<Composition>().Returns(compositionList.AsQueryable());

        var service = RetrieveService();

        // Act
        var result = service.GetCompositions();

        // Assert
        result.Should().BeEquivalentTo(compositionList, options => options.ExcludingMissingMembers());
    }
    
}