using Binus.Flight.Core.Constant.Entity;
using FluentValidation;

namespace Binus.Flight.Core.Application.Command.Post.Commands.AddPostCommentByUser
{
    public class AddPostCommentByUserCommandValidator : AbstractValidator<AddPostCommentByUserCommand>
    {
        public AddPostCommentByUserCommandValidator()
        {
            RuleFor(prop => prop.Content)
                .MaximumLength(PostEntityConstant.ContentLength)
                .NotEmpty();
        }
    }
}