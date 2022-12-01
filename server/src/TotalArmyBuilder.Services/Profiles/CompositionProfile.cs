using AutoMapper;
using TotalArmyBuilder.Dal.Models;
using TotalArmyBuilder.Service.DTOs;

namespace TotalArmyBuilder.Service.Profiles;

public class CompositionProfile : Profile
{
    public CompositionProfile()
    {
        ConfigureDomainToDtoModel();
        ConfigureDtoToDomainModel();
    }

    private void ConfigureDomainToDtoModel()
    {
        CreateMap<Composition, CompositionDto>();
    }

    private void ConfigureDtoToDomainModel()
    {
        CreateMap<CompositionDto, Composition>();
    }
}