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

public class CompositionServiceTests
{
    private readonly ITotalArmyDatabase _database;
    private readonly IMapper _mapper;
    private readonly IFixture _fixture;
    
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
        _fixture = new Fixture();
    }

    [Fact]
    public void GetCompositionById_WhenCompositionExist_ReturnsComposition()
    {
        // Arrange
        _fixture.Customize(new CompositionCustomisation("test"));
        var compositionList = _fixture.CreateMany<Composition>(5);
        _database.Get<Composition>().Returns(compositionList.AsQueryable());

        var service = RetrieveService();

        // Act
        var result = service.GetCompositionById(compositionList.First().Id);

        // Assert
        result.Should().BeEquivalentTo(compositionList.First(), options => options.ExcludingMissingMembers());
    }
    
    [Fact]
    public void GetCompositions_WhenCompositionsExist_ReturnsCompositions()
    {
        // Arrange
        _fixture.Customize(new CompositionCustomisation("test"));
        var compositionList = _fixture.CreateMany<Composition>(5);
        _database.Get<Composition>().Returns(compositionList.AsQueryable());

        var service = RetrieveService();

        // Act
        var result = service.GetCompositions();

        // Assert
        result.Should().BeEquivalentTo(compositionList, options => options.ExcludingMissingMembers());
    }
    
    [Fact]
    public void CreateComposition_MappedAndSaved()
    {
        // Arrange
        _fixture.Customize(new CompositionCustomisation("test"));
        var composition = _fixture.Create<Composition>();
        var service = RetrieveService();

        // Act
        service.CreateComposition(_mapper.Map<CompositionDto>(composition));

        // Assert
        _database.Received(1).SaveChanges();
        _database.Received(1).Add(Arg.Is<Composition>(x => x.Name == composition.Name));
    }
    
    [Fact]
    public void UpdateComposition_MappedAndSaved()
    {
        // Arrange
        // Arrange
        _fixture.Customize(new CompositionCustomisation("test"));
        var compositionList = _fixture.CreateMany<Composition>(5);
        var compositionDto = _mapper.Map<CompositionDto>(compositionList.First());
        
        _database.Get<Composition>().Returns(compositionList.AsQueryable());
        
        var service = RetrieveService();

        // Act
        service.UpdateComposition(compositionList.First().Id, compositionDto);

        // Assert
        _database.Received(1).Get<Composition>();
        _database.Received(1).SaveChanges();
    }
}