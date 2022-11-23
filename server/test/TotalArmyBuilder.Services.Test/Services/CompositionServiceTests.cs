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
            cfg.AddProfile<AccountProfile>();
            cfg.AddProfile<CompositionProfile>();
            cfg.AddProfile<FactionProfile>();
            cfg.AddProfile<UnitProfile>();
        });

        return new Mapper(config);
    }

    public CompositionServiceTests()
    {
        _database = Substitute.For<ITotalArmyDatabase>();
        _mapper = GetMapper();
        _fixture = new Fixture();
        
        _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
            .ForEach(b => _fixture.Behaviors.Remove(b));
        _fixture.Behaviors.Add(new OmitOnRecursionBehavior(1));
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
    public void GetCompositionUnits_WhenUnitsExist_ReturnsUnits()
    {
        // Arrange
        const int compositionId = 1;
        const int unitId = 1;
        
        var compositionUnitList =_fixture
            .Build<CompositionUnit>()
            .With(x=> x.CompositionId, compositionId)
            .With(x=> x.UnitId, unitId)
            .CreateMany(1)
            .ToList();
        
        var unitList =_fixture
            .Build<Unit>()
            .With(x => x.Id, unitId)
            .With(x => x.CompositionUnits, compositionUnitList)
            .CreateMany(1)
            .AsQueryable();
        
        _database.Get<Unit>().Returns(unitList);
        
        var service = RetrieveService();
        
        // Act
        var result = service.GetCompositionUnits(compositionId);

        // Assert
        result.Should().BeEquivalentTo(unitList, options => options.ExcludingMissingMembers());
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
    
    [Fact]
    public void DeleteComposition_MappedAndSaved()
    {
        // Arrange
        _fixture.Customize(new CompositionCustomisation("test"));
        var compositionList = _fixture.CreateMany<Composition>(5);

        _database.Get<Composition>().Returns(compositionList.AsQueryable());
        
        var service = RetrieveService();

        // Act
        service.DeleteComposition(compositionList.First().Id);

        // Assert
        _database.Received(1).Get<Composition>();
        _database.Received(1).SaveChanges();
    }
}