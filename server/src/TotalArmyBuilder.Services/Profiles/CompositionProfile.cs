using AutoMapper;
using TotalArmyBuilder.Dal.Models;
using TotalArmyBuilder.Service.DTOs;
using TotalArmyBuilder.Service.Services;

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
        CreateMap<Composition, CompositionDto>()
            .ForMember(d => d.Accounts, 
                o=> o
                    .MapFrom(x => x.AccountCompositions.Select(y => y.Account)))
            .ForAllMembers(opts => 
                    opts.Condition((src, dest, srcMember) => srcMember != null));
        
    }
    
    private void ConfigureDtoToDomainModel()
    {
        CreateMap<CompositionDto, Composition>()
            .ForMember(d => d.Id, 
                o => o.Ignore())
            .ForAllMembers(opts => 
                    opts.Condition((src, dest, srcMember) => srcMember != null));
        
        CreateMap<CompositionDto, Composition>();
    }
}