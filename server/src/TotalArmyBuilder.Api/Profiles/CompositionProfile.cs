using AutoMapper;
using TotalArmyBuilder.Api.Extensions;
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
        CreateMap<CompositionDto, CompositionViewModel>().IgnoreAllNull();
        CreateMap<CompositionDto, CompositionDetailViewModel>().IgnoreAllNull();
    }

    private void ConfigureCreateModelToDto()
    {
        CreateMap<CompositionViewModel, CompositionDto>().IgnoreAllNull();
        CreateMap<CreateCompositionViewModel, CompositionDto>().IgnoreAllNull();
        CreateMap<UpdateCompositionViewModel, CompositionDto>().IgnoreAllNull();
    }
}