using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IGR.Core.Application.Commons;
using IGR.Core.Application.Domain.Post.Commands.AddPostCommentByUser;
using IGR.Core.Application.Domain.Post.Commands.CreatePostByUser;
using IGR.Core.Application.Domain.Post.Queries.GetPostWithLatestComment;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IGR.WebAPI.Controllers
{
    public class PostController : BaseController
    {
        #region Constructors

        public PostController(IMediator mediator) : base(mediator)
        {
        }

        #endregion

        #region APIs

        [HttpPost]
        public async Task<ActionResult<BaseCommandResult>> Create(IFormCollection form)
        {
            var command = new CreatePostByUserCommand
            {
                Caption = form[nameof(CreatePostByUserCommand.Caption)]
            };

            if (form.Files.Any(item => item.Name == nameof(CreatePostByUserCommand.ImageFile)))
            {
                var imageFile = form.Files.FirstOrDefault(item => item.Name == nameof(CreatePostByUserCommand.ImageFile));
                command.ImageFile = imageFile?.OpenReadStream();
                command.ImageFileName = imageFile?.FileName;
            }
            
            return await Mediator.Send(command);
        }
        
        [HttpPost]
        public async Task<ActionResult<BaseCommandResult>> AddComment(AddPostCommentByUserCommand command)
        {
            return await Mediator.Send(command);
        }
        
        [HttpGet]
        public async Task<ActionResult<BaseQueryResult<List<GetPostWithLatestCommentDto>>>> Get(int startIndex, int length)
        {
            return await Mediator.Send(new GetPostWithLatestCommentQuery
            {
                StartIndex = startIndex,
                Length = length
            });
        }

        #endregion
    }
}