using Binus.ActivitiesVendor.Core.Constant.Entity;
using FluentValidation;

namespace Binus.ActivitiesVendor.Core.Application.Command.Common.Account.Commands.CreateAccount
{
    public class CreateAccountCommandValidator : AbstractValidator<CreateAccountCommand>
    {
        public CreateAccountCommandValidator()
        {
            RuleFor(prop => prop.Name)
                .MaximumLength(CommonEntityConstant.NameLength)
                .NotEmpty();

            RuleFor(prop => prop.Email)
                .EmailAddress()
                .NotEmpty();

            RuleFor(prop => prop.Password)
                .NotEmpty();
        }
    }
}