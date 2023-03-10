using System.IO;
using Binus.AccommodationAgoda.Core.Application.Commons;
using MediatR;

namespace Binus.AccommodationAgoda.Core.Application.Command.Post.Commands.CreatePostByUser
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