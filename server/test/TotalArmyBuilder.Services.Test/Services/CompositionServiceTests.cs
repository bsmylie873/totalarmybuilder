using AutoFixture;
using AutoMapper;
using FluentAssertions;
using NSubstitute;
using TotalArmyBuilder.Dal.Interfaces;
using TotalArmyBuilder.Dal.Models;
using TotalArmyBuilder.Service.DTOs;
using TotalArmyBuilder.Service.Interfaces;
using TotalArmyBuilder.Service.Profiles;
using TotalArmyBuilder.Service.Services;
using TotalArmyBuilder.Service.Services.Exceptions;
using TotalArmyBuilder.Services.Test.Customisations;
using TotalArmyBuilder.Services.Test.Extensions;

namespace TotalArmyBuilder.Services.Test.Services;

public class CompositionServiceTests
{
    private readonly ITotalArmyDatabase _database;
    private readonly IFixture _fixture;
    private readonly IMapper _mapper;

    public CompositionServiceTests()
    {
        _database = Substitute.For<ITotalArmyDatabase>();
        _mapper = GetMapper();
        _fixture = new Fixture();

        _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
            .ForEach(b => _fixture.Behaviors.Remove(b));
        _fixture.Behaviors.Add(new OmitOnRecursionBehavior(1));
    }

    private ICompositionService RetrieveService()
    {
        return new CompositionService(_database, _mapper);
    }

    private static IMapper GetMapper()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<AccountProfile>();
            cfg.AddProfile<CompositionProfile>();
            cfg.AddProfile<UnitProfile>();
        });

        return new Mapper(config);
    }


    [Fact]
    public void GetCompositionById_WhenCompositionExist_ReturnsComposition()
    {
        // Arrange
        const int compositionId = 1;

        var compositionIds = _fixture.MockWithOne(compositionId);

        _fixture.Customize(new CompositionCustomisation());
        var compositionList = _fixture
            .Build<Composition>()
            .With(x => x.Id, compositionIds.GetValue)
            .CreateMany(5)
            .AsQueryable();
        _database.Get<Composition>().Returns(compositionList);

        var service = RetrieveService();

        // Act
        var result = service.GetCompositionById(compositionId);

        // Assert
        result.Should().BeEquivalentTo(compositionList.First(), options => options.ExcludingMissingMembers());
    }

    [Fact]
    public void GetCompositions_WhenCompositionsExist_ReturnsCompositions()
    {
        _fixture.Customize(new CompositionCustomisation());
        var compositionList = _fixture.CreateMany<Composition>(5).AsQueryable();
        _database.Get<Composition>().Returns(compositionList);

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

        var compositionIds = _fixture.MockWithOne(compositionId);

        var compositionUnitList = _fixture
            .Build<CompositionUnit>()
            .With(x => x.CompositionId, compositionIds.GetValue)
            .With(x => x.UnitId, unitId)
            .CreateMany(5)
            .ToList();

        var unitList = _fixture
            .Build<Unit>()
            .With(x => x.Id, unitId)
            .With(x => x.CompositionUnits, compositionUnitList)
            .CreateMany(5)
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
        _fixture.Customize(new CompositionCustomisation());
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
        const int compositionId = 1;

        var compositionIds = _fixture.MockWithOne(compositionId);

        _fixture.Customize(new CompositionCustomisation());
        var compositionList = _fixture
            .Build<Composition>()
            .With(x => x.Id, compositionIds.GetValue)
            .CreateMany(5)
            .AsQueryable();
        _database.Get<Composition>().Returns(compositionList);

        var compositionDto = _fixture
            .Build<CompositionDto>()
            .Without(x => x.Accounts)
            .Without(x => x.Units)
            .With(x => x.Id, compositionId)
            .Create();

        _database.Get<Composition>().Returns(compositionList);

        var service = RetrieveService();

        _database.When(x => x.SaveChanges()).Do(x =>
        {
            compositionList.First()
                .Should()
                .BeEquivalentTo(compositionDto, o => o.ExcludingMissingMembers());
        });

        // Act
        service.UpdateComposition(compositionId, compositionDto);

        // Assert
        _database.Received(1).Get<Composition>();
        _database.Received(1).SaveChanges();
    }

    [Fact]
    public void UpdateComposition_CompositionDoesNotExist_ThrowsNotFoundException()
    {
        // Arrange
        const int compositionId = 1;
        const int wrongId = 2;

        var compositionIds = _fixture.MockWithOne(compositionId);

        _fixture.Customize(new CompositionCustomisation());
        var compositionList = _fixture
            .Build<Composition>()
            .With(x => x.Id, compositionIds.GetValue)
            .CreateMany(1)
            .AsQueryable();
        _database.Get<Composition>().Returns(compositionList);

        var compositionDto = _fixture
            .Build<CompositionDto>()
            .Without(x => x.Accounts)
            .Without(x => x.Units)
            .With(x => x.Id, compositionId)
            .Create();

        _database.Get<Composition>().Returns(compositionList);

        var service = RetrieveService();

        // Act & Assert
        Assert.Throws<NotFoundException>(() => service.UpdateComposition(wrongId, compositionDto));
    }

    [Fact]
    public void DeleteComposition_MappedAndSaved()
    {
        // Arrange
        const int compositionId = 1;

        var compositionIds = _fixture.MockWithOne(compositionId);

        _fixture.Customize(new CompositionCustomisation());
        var compositionList = _fixture
            .Build<Composition>()
            .With(x => x.Id, compositionIds.GetValue)
            .CreateMany(5)
            .AsQueryable();

        _database.Get<Composition>().Returns(compositionList);

        var service = RetrieveService();

        // Act
        service.DeleteComposition(compositionId);

        // Assert
        _database.Received(1).Get<Composition>();
        _database.Received(1).SaveChanges();
    }

    [Fact]
    public void DeleteComposition_CompositionDoesNotExist_ThrowsNotFoundException()
    {
        // Arrange
        const int compositionId = 1;
        const int wrongId = 2;

        var compositionIds = _fixture.MockWithOne(compositionId);

        _fixture.Customize(new CompositionCustomisation());
        var compositionList = _fixture
            .Build<Composition>()
            .With(x => x.Id, compositionIds.GetValue)
            .CreateMany(1)
            .AsQueryable();

        _database.Get<Composition>().Returns(compositionList);

        var service = RetrieveService();

        // Act & Assert
        Assert.Throws<NotFoundException>(() => service.DeleteComposition(wrongId));
    }
}