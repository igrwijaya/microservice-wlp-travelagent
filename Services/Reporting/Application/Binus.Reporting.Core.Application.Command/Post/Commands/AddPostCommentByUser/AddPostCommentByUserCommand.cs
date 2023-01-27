using Binus.Reporting.Core.Application.Commons;
using MediatR;

namespace Binus.Reporting.Core.Application.Command.Post.Commands.AddPostCommentByUser
{
    public class AddPostCommentByUserCommand : IRequest<BaseCommandResult>
    {
        #region Properties

        public int PostId { get; set; }

        public string Content { get; set; }

        #endregion
    }
}