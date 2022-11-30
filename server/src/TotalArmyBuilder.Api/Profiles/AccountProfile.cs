using AutoMapper;
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
        CreateMap<AccountDto, AccountViewModel>().ForAllMembers(
            opts =>
                opts.Condition((src, dest, srcMember) => srcMember != null));
        CreateMap<AccountDto, AccountDetailViewModel>().ForAllMembers(
            opts =>
                opts.Condition((src, dest, srcMember) => srcMember != null));
    }

    private void ConfigureCreateModelToDto()
    {
        CreateMap<CreateAccountViewModel, AccountDto>().ForAllMembers(
            opts =>
                opts.Condition((src, dest, srcMember) => srcMember != null));
        CreateMap<UpdateAccountViewModel, AccountDto>().ForAllMembers(
            opts =>
                opts.Condition((src, dest, srcMember) => srcMember != null));
    }
}