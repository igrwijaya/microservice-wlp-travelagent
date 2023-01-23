using System.Threading;
using System.Threading.Tasks;
using Binus.Flight.Core.Application.Commons;
using Binus.Flight.Core.Application.Services;
using Binus.Flight.Core.Domain.AggregateRoots.Post;
using MediatR;

namespace Binus.Flight.Core.Application.Command.Post.Commands.AddPostCommentByUser
{
    public class AddPostCommentByUserCommandHandler : IRequestHandler<AddPostCommentByUserCommand, BaseCommandResult>
    {
        #region Fields

        private readonly ISessionUserService _sessionUserService;
        private readonly IPostRepository _postRepository;

        #endregion

        #region Constructors

        public AddPostCommentByUserCommandHandler(ISessionUserService sessionUserService, IPostRepository postRepository)
        {
            _sessionUserService = sessionUserService;
            _postRepository = postRepository;
        }

        #endregion

        #region Public Methods

        public async Task<BaseCommandResult> Handle(AddPostCommentByUserCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResult();
            var accountId = _sessionUserService.AccountId;
            var post = await _postRepository.ReadAsync(request.PostId);

            if (post == null)
            {
                response.AddErrorMessage("Post not found");
                return response;
            }
            
            post.AddComment(accountId, request.Content);
            await _postRepository.UpdateAsync(post);

            return response;
        }

        #endregion
        
    }
}