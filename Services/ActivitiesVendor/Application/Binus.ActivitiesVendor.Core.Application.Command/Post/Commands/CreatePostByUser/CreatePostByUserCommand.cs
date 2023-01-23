using System.IO;
using Binus.ActivitiesVendor.Core.Application.Commons;
using MediatR;

namespace Binus.ActivitiesVendor.Core.Application.Command.Post.Commands.CreatePostByUser
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