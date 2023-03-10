using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Binus.Activities.Core.Application.Command.Post.Commands.AddPostCommentByUser;
using Binus.Activities.Core.Application.Command.Post.Commands.CreatePostByUser;
using Binus.Activities.Core.Application.Command.Post.Queries.GetPostWithLatestComment;
using Binus.Activities.Core.Application.Commons;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Binus.Services.Activities.API.Controllers
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