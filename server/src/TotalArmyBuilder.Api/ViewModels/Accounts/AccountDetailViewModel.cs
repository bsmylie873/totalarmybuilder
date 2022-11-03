namespace TotalArmyBuilder.Api.ViewModels.Accounts;
using FluentValidation;
public class AccountDetailViewModel : AccountViewModel
{
    public int Id { get; set; }
}

public class AccountDetailViewModelValidator : AbstractValidator<AccountDetailViewModel> 
{
    public AccountDetailViewModelValidator() 
    {
        RuleFor(x => x.Id).NotNull();
    }
}