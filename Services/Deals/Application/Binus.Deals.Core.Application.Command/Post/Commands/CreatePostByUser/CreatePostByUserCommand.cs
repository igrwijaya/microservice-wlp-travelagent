using System.IO;
using Binus.Deals.Core.Application.Commons;
using MediatR;

namespace Binus.Deals.Core.Application.Command.Post.Commands.CreatePostByUser
{
    public class CreatePostByUserCommand : IRequest<BaseCommandResult>
    {
        #region Properties

        public string Caption { get; set; }

        public Stream ImageFile { get; set; }

        public string ImageFileName { get; set; }

        #endregion
    }
}