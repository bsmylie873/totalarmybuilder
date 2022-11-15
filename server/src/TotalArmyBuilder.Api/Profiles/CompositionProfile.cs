using AutoMapper;
using TotalArmyBuilder.Api.ViewModels.Compositions;
using TotalArmyBuilder.Service.DTOs;

namespace TotalArmyBuilder.Api.Profiles;

public class CompositionProfile : Profile
{
    public CompositionProfile()
    {
        ConfigureDtoToViewModel();
        ConfigureCreateModelToDto();
    }

    private void ConfigureDtoToViewModel()
    {
        CreateMap<CompositionDto, CompositionViewModel>().ForAllMembers(
            opts => 
                opts.Condition((src, dest, srcMember) => srcMember != null));

    }

    private void ConfigureCreateModelToDto()
    {
        CreateMap<CreateCompositionViewModel, CompositionDto>().ForAllMembers(
            opts => 
                opts.Condition((src, dest, srcMember) => srcMember != null));
        CreateMap<UpdateCompositionViewModel, CompositionDto>().ForAllMembers(
            opts => 
                opts.Condition((src, dest, srcMember) => srcMember != null));
    } 
}