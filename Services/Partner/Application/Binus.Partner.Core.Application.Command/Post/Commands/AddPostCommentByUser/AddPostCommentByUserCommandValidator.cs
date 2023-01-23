using Binus.Partner.Core.Constant.Entity;
using FluentValidation;

namespace Binus.Partner.Core.Application.Command.Post.Commands.AddPostCommentByUser
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