using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using TotalArmyBuilder.Api.Controllers;
using TotalArmyBuilder.Api.Test.Extensions;
using TotalArmyBuilder.Api.ViewModels.Factions;
using TotalArmyBuilder.Api.ViewModels.Units;
using TotalArmyBuilder.Service.DTOs;
using TotalArmyBuilder.Service.Interfaces;

namespace TotalArmyBuilder.Api.Test.Controllers;

public class UnitControllerTests
{
    private readonly IMapper _mapper;
    private readonly IUnitService _service;
    
    private UnitsController RetrieveController()
    {
        return new UnitsController(_mapper, _service);
    } 

    public UnitControllerTests()
    {
        _mapper = Substitute.For<IMapper>();
        _service = Substitute.For<IUnitService>();
    }

    [Theory]
    [InlineData("name", 0)]
    [InlineData(null, null)]
    public void GetUnits_MappedAndReturned(string name, int cost)
    {
        // Arrange
        const int id = 1;
        var unit = new UnitDto
        {
            Id = id,
            Name = name,
            Cost = cost
        };
        
        const int id2 = 2;
        var unit2 = new UnitDto
        {
            Id = id2,
            Name = name,
            Cost = cost
        };

        var unitList = new List<UnitDto>
        {
            unit, unit2
        };

        var unitViewModels = new List<UnitViewModel>();

        _service.GetUnits(name).Returns(unitList);
        _mapper.Map<IList<UnitViewModel>>(unitList).Returns(unitViewModels);

        var controller = RetrieveController();
        
        // Act
        var actionResult = controller.GetUnits(name, cost);
        
        // Assert
        var result = actionResult.AssertObjectResult<IList<UnitViewModel>, OkObjectResult>();

        result.Should().BeSameAs(unitViewModels);

        _service.Received(1).GetUnits(name, cost);
        _mapper.Received(1).Map<IList<UnitViewModel>>(unitList);
    }
    
    [Fact]
    public void GetUnitById_WhenUnitFound_MappedAndReturned()
    {
        // Arrange
        const int id = 1;
        var unit = new UnitDto
        {
            Id = id
        };

        var unitDetailViewModel = new UnitDetailViewModel();

        _service.GetUnitById(id).Returns(unit);
        _mapper.Map<UnitDetailViewModel>(unit).Returns(unitDetailViewModel);

        var controller = RetrieveController();
        
        // Act
        var actionResult = controller.GetUnitById(id);
        
        // Assert
        var result = actionResult.AssertObjectResult<UnitDetailViewModel, OkObjectResult>();

        result.Should().BeSameAs(unitDetailViewModel);

        _service.Received(1).GetUnitById(id);
        _mapper.Received(1).Map<UnitDetailViewModel>(unit);
    }
    
    [Fact]
    public void GetUnitFactions_MappedAndReturned()
    {
        // Arrange
        const int id = 1;
        
        var faction = new FactionDto
        {
            Id = id
        };
        
        const int id2 = 2;
        var faction2 = new FactionDto
        {
            Id = id2
        };
        
        var factionList = new List<FactionDto>
        {
            faction, faction2
        };
        
        var unit = new UnitDto()
        {
            Id = id,
            Factions = factionList
        };


        var factionViewModels = new List<FactionViewModel>();

        _service.GetUnitFactions(unit.Id).Returns(unit.Factions);
        _mapper.Map<IList<FactionViewModel>>(unit.Factions).Returns(factionViewModels);

        var controller = RetrieveController();
        
        // Act
        var actionResult = controller.GetUnitFactions(faction.Id);
        
        // Assert
        var result = actionResult.AssertObjectResult<IList<FactionViewModel>, OkObjectResult>();

        result.Should().BeSameAs(factionViewModels);

        _service.Received(1).GetUnitFactions(unit.Id);
        _mapper.Received(1).Map<IList<FactionViewModel>>(unit.Factions);
    }
}