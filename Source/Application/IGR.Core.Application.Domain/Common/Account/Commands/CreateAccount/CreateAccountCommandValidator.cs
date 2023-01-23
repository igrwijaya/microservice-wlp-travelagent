using FluentValidation;
using IGR.Core.Constant.Entity;

namespace IGR.Core.Application.Domain.Common.Account.Commands.CreateAccount
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