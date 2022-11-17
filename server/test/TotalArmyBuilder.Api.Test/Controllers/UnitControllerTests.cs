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

        _service.GetUnits(name, cost).Returns(unitList);
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
    public void GetUnitFactions_WhenUnitFound_MappedAndReturned()
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
    
    [Fact]
    public void GetUnitLords_WhenUnitFound_MappedAndReturned()
    {
        // Arrange
        const int id = 1;
        
        var lord = new UnitDto
        {
            Id = id
        };
        
        const int id2 = 2;
        var lord2 = new UnitDto
        {
            Id = id2
        };
        
        var lordList = new List<UnitDto>
        {
            lord, lord2
        };
        
        var unit = new UnitDto()
        {
            Id = id,
            Lords = lordList
        };


        var lordViewModels = new List<UnitViewModel>();

        _service.GetUnitLords(unit.Id).Returns(unit.Lords);
        _mapper.Map<IList<UnitViewModel>>(unit.Lords).Returns(lordViewModels);

        var controller = RetrieveController();
        
        // Act
        var actionResult = controller.GetUnitLords(unit.Id);
        
        // Assert
        var result = actionResult.AssertObjectResult<IList<UnitViewModel>, OkObjectResult>();

        result.Should().BeSameAs(lordViewModels);

        _service.Received(1).GetUnitLords(unit.Id);
        _mapper.Received(1).Map<IList<UnitViewModel>>(unit.Lords);
    }
    
    [Fact]
    public void GetUnitHeroes_WhenUnitFound_MappedAndReturned()
    {
        // Arrange
        const int id = 1;
        
        var hero = new UnitDto
        {
            Id = id
        };
        
        const int id2 = 2;
        var hero2 = new UnitDto
        {
            Id = id2
        };
        
        var heroList = new List<UnitDto>
        {
            hero, hero2
        };
        
        var unit = new UnitDto()
        {
            Id = id,
            Heroes = heroList
        };


        var heroViewModels = new List<UnitViewModel>();

        _service.GetUnitHeroes(unit.Id).Returns(unit.Heroes);
        _mapper.Map<IList<UnitViewModel>>(unit.Heroes).Returns(heroViewModels);

        var controller = RetrieveController();
        
        // Act
        var actionResult = controller.GetUnitHeroes(unit.Id);
        
        // Assert
        var result = actionResult.AssertObjectResult<IList<UnitViewModel>, OkObjectResult>();

        result.Should().BeSameAs(heroViewModels);

        _service.Received(1).GetUnitHeroes(unit.Id);
        _mapper.Received(1).Map<IList<UnitViewModel>>(unit.Heroes);
    }
}