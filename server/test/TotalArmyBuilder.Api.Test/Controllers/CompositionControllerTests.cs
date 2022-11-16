using System.Collections;
using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using TotalArmyBuilder.Api.Controllers;
using TotalArmyBuilder.Api.Test.Extensions;
using TotalArmyBuilder.Api.ViewModels.Accounts;
using TotalArmyBuilder.Api.ViewModels.Compositions;
using TotalArmyBuilder.Dal.Interfaces;
using TotalArmyBuilder.Dal.Specifications.Accounts;
using TotalArmyBuilder.Service.DTOs;
using TotalArmyBuilder.Service.Interfaces;


namespace TotalArmyBuilder.Api.Test.Controllers;

public class CompositionControllerTests
{
    private readonly IMapper _mapper;
    private readonly ICompositionService _service;

    public CompositionControllerTests()
    {
        _mapper = Substitute.For<IMapper>();
        _service = Substitute.For<ICompositionService>();
    }

    [Fact]
    public void GetCompositionById_WhenCompositionFound_MappedAndReturned()
    {
        // Arrange
        const int id = 1;
        var composition = new CompositionDto
        {
            Id = id
        };

        var compositionDetailViewModel = new CompositionDetailViewModel();

        _service.GetCompositionById(id).Returns(composition);
        _mapper.Map<CompositionDetailViewModel>(composition).Returns(compositionDetailViewModel);

        var controller = RetrieveController();
        
        // Act
        var actionResult = controller.GetCompositionById(id);
        
        // Assert
        var result = actionResult.AssertObjectResult<CompositionDetailViewModel, OkObjectResult>();

        result.Should().BeSameAs(compositionDetailViewModel);

        _service.Received(1).GetCompositionById(id);
        _mapper.Received(1).Map<CompositionDetailViewModel>(composition);
    }
    
    [Theory]
    [InlineData("name", 0, 0)]
    [InlineData(null, null, null)]
    public void GetCompositions_MappedAndReturned(string name, int battleType, int factionId)
    {
        // Arrange
        const int id = 1;
        var composition = new CompositionDto
        {
            Id = id,
            Name = name,
            BattleType = battleType,
            FactionId = factionId,
        };
        
        const int id2 = 2;
        var composition2 = new CompositionDto
        {
            Id = id2,
            Name = name,
            BattleType = battleType,
            FactionId = factionId,
        };

        var compositionList = new List<CompositionDto>
        {
            composition, composition2
        };

        var compositionViewModels = new List<CompositionViewModel>();

        _service.GetCompositions(name, battleType, factionId).Returns(compositionList);
        _mapper.Map<IList<CompositionViewModel>>(compositionList).Returns(compositionViewModels);

        var controller = RetrieveController();
        
        // Act
        var actionResult = controller.GetCompositions(name, battleType, factionId);
        
        // Assert
        var result = actionResult.AssertObjectResult<IList<CompositionViewModel>, OkObjectResult>();
        
        result.Should().BeSameAs(compositionViewModels);

        _service.Received(1).GetCompositions(name, battleType, factionId);
        _mapper.Received(1).Map<IList<CompositionViewModel>>(compositionList);
    }
    
    private CompositionsController RetrieveController()
    {
        return new CompositionsController(_mapper, _service);
    }
}