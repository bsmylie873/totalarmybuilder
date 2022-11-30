using AutoMapper;
using TotalArmyBuilder.Api.Extensions;
using TotalArmyBuilder.Api.ViewModels.Accounts;
using TotalArmyBuilder.Service.DTOs;

namespace TotalArmyBuilder.Api.Profiles;

public class AccountProfile : Profile
{
    public AccountProfile()
    {
        ConfigureDtoToViewModel();
        ConfigureCreateModelToDto();
    }

    private void ConfigureDtoToViewModel()
    {
        CreateMap<AccountDto, AccountViewModel>().IgnoreAllNull();
        CreateMap<AccountDto, AccountDetailViewModel>().IgnoreAllNull();
    }

    private void ConfigureCreateModelToDto()
    {
        CreateMap<CreateAccountViewModel, AccountDto>().IgnoreAllNull();
        CreateMap<UpdateAccountViewModel, AccountDto>().IgnoreAllNull();
    }
}