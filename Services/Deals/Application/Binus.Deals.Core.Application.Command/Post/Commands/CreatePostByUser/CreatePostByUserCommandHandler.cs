using System;
using System.Threading;
using System.Threading.Tasks;
using Binus.Deals.Core.Application.Commons;
using Binus.Deals.Core.Application.Services;
using Binus.Deals.Core.Constant.Constant;
using Binus.Deals.Core.Domain.AggregateRoots.Post;
using MediatR;

namespace Binus.Deals.Core.Application.Command.Post.Commands.CreatePostByUser
{
    public class CreatePostByUserCommandHandler : IRequestHandler<CreatePostByUserCommand, BaseCommandResult>
    {
        #region Fields

        private readonly IPostRepository _postRepository;
        private readonly ISessionUserService _sessionUserService;
        private readonly IStorageService _storageService;

        #endregion

        #region Constructors

        public CreatePostByUserCommandHandler(IPostRepository postRepository, ISessionUserService sessionUserService, IStorageService storageService)
        {
            _postRepository = postRepository;
            _sessionUserService = sessionUserService;
            _storageService = storageService;
        }

        #endregion

        #region Public Methods

        public async Task<BaseCommandResult> Handle(CreatePostByUserCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResult();
            var accountId = _sessionUserService.AccountId;
            var post = new Deals.Core.Domain.AggregateRoots.Post.Post(accountId, request.Caption);

            if (request.ImageFile == null)
            {
                await _postRepository.CreateAsync(post);

                return response;
            }
            
            var fileName = string.Format(
                StorageConstant.PostImageFormat,
                accountId,
                Guid.NewGuid(), 
                StorageConstant.DefaultImageFormat);
            
            var uploadImageResponse = await _storageService.UploadAsync(
                ConfigurationConstant.AwsS3PostBucket,
                fileName,
                request.ImageFile);

            if (!uploadImageResponse.IsSuccess)
            {
                response.AddErrorMessage("Failed to upload the image");
                return response;
            }
            
            post.AddImage(uploadImageResponse.FileName);
            
            await _postRepository.CreateAsync(post);

            return response;
        }

        #endregion
        
    }
}