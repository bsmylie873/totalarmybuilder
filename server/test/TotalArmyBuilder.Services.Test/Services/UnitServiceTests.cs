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

public class UnitServiceTests
{
    private readonly ITotalArmyDatabase _database;
    private readonly IMapper _mapper;
    
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
    }

    [Fact]
    public void GetUnitById_WhenUnitExist_ReturnsUnit()
    {
        // Arrange
        const int id = 1;
        const int id2 = 2;

        var unit = new Unit
        {
            Id = id
        };
        
        var unit2 = new Unit
        {
            Id = id2
        };

        var unitList = new List<Unit>
        {
            unit, unit2
        };

        _database.Get<Unit>().Returns(unitList.AsQueryable());

        var service = RetrieveService();

        // Act
        var result = service.GetUnitById(id);

        // Assert
        result.Should().BeEquivalentTo(unit, options => options.ExcludingMissingMembers());
    }
    
    [Theory, AutoData]
    public void GetUnits_WhenUnitsExist_ReturnsUnits(string name, int cost)
    {
        // Arrange
        const int id = 1;
        const int id2 = 2;

        var unit = new Unit
        {
            Id = id,
            Name = name,
        };
        
        var unit2 = new Unit
        {
            Id = id2,
            Name = name,
        };

        var unitList = new List<Unit>
        {
            unit, unit2
        };

        _database.Get<Unit>().Returns(unitList.AsQueryable());

        var service = RetrieveService();

        // Act
        var result = service.GetUnits();

        // Assert
        result.Should().BeEquivalentTo(unitList, options => options.ExcludingMissingMembers());
    }
}