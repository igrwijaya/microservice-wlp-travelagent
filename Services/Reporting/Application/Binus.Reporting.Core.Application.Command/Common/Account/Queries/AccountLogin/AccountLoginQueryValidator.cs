using FluentValidation;

namespace Binus.Customer.Core.Application.Command.Common.Account.Queries.AccountLogin
{
    public class AccountLoginQueryValidator : AbstractValidator<AccountLoginQuery>
    {
        public AccountLoginQueryValidator()
        {
            RuleFor(prop => prop.Email)
                .EmailAddress()
                .NotEmpty();

            RuleFor(prop => prop.Password)
                .NotEmpty();
        }
    }
}