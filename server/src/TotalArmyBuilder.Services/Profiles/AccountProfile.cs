using AutoMapper;
using TotalArmyBuilder.Dal.Models;
using TotalArmyBuilder.Service.DTOs;

namespace TotalArmyBuilder.Service.Profiles;

public class AccountProfile : Profile
{
    public AccountProfile()
    {
        ConfigureDomainToDtoModel();
        ConfigureDtoToDomainModel();
    }

    private void ConfigureDomainToDtoModel()
    {
        CreateMap<Account, AccountDto>()
            .ForAllMembers(opts =>
                opts.Condition((src, dest, srcMember) => srcMember != null));
    }

    private void ConfigureDtoToDomainModel()
    {
        CreateMap<AccountDto, Account>()
            .ForAllMembers(opts =>
                opts.Condition((src, dest, srcMember) => srcMember != null));
    }
}