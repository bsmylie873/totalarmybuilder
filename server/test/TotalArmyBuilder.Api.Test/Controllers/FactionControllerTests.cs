using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using TotalArmyBuilder.Api.Controllers;
using TotalArmyBuilder.Api.Test.Extensions;
using TotalArmyBuilder.Api.ViewModels.Factions;
using TotalArmyBuilder.Service.DTOs;
using TotalArmyBuilder.Service.Interfaces;

namespace TotalArmyBuilder.Api.Test.Controllers;

public class FactionControllerTests
{
    private readonly IMapper _mapper;
    private readonly IFactionService _service;

    public FactionControllerTests()
    {
        _mapper = Substitute.For<IMapper>();
        _service = Substitute.For<IFactionService>();
    }

    [Fact]
    public void GetFactionById_WhenFactionFound_MappedAndReturned()
    {
        // Arrange
        const int id = 1;
        var faction = new FactionDto
        {
            Id = id
        };

        var factionDetailViewModel = new FactionDetailViewModel();

        _service.GetFactionById(id).Returns(faction);
        _mapper.Map<FactionDetailViewModel>(faction).Returns(factionDetailViewModel);

        var controller = RetrieveController();
        
        // Act
        var actionResult = controller.GetFactionById(id);
        
        // Assert
        var result = actionResult.AssertObjectResult<FactionDetailViewModel, OkObjectResult>();

        result.Should().BeSameAs(factionDetailViewModel);

        _service.Received(1).GetFactionById(id);
        _mapper.Received(1).Map<FactionDetailViewModel>(faction);
    }
    
    [Theory]
    [InlineData("name")]
    [InlineData(null)]
    public void GetFactions_MappedAndReturned(string name)
    {
        // Arrange
        const int id = 1;
        var faction = new FactionDto
        {
            Id = id,
            Name = name
        };
        
        const int id2 = 2;
        var faction2 = new FactionDto
        {
            Id = id2,
            Name = name
        };

        var factionList = new List<FactionDto>
        {
            faction, faction2
        };

        var factionViewModels = new List<FactionViewModel>();

        _service.GetFactions(name).Returns(factionList);
        _mapper.Map<IList<FactionViewModel>>(factionList).Returns(factionViewModels);

        var controller = RetrieveController();
        
        // Act
        var actionResult = controller.GetFactions(name);
        
        // Assert
        var result = actionResult.AssertObjectResult<IList<FactionViewModel>, OkObjectResult>();
        
        result.Should().BeSameAs(factionViewModels);

        _service.Received(1).GetFactions(name);
        _mapper.Received(1).Map<IList<FactionViewModel>>(factionList);
    }
    
    private FactionsController RetrieveController()
    {
        return new FactionsController(_mapper, _service);
    } 
}