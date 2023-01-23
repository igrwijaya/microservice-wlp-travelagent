using System.Threading;
using System.Threading.Tasks;
using IGR.Core.Application.Commons;
using IGR.Core.Application.Services;
using IGR.Core.Constant.Constant;
using IGR.Core.Domain.AggregateRoots.Account;
using IGR.Core.Domain.AggregateRoots.Post;
using MediatR;

namespace IGR.Core.Application.Domain.Common.Account.Commands.RemoveAccount
{
    public class RemoveAccountCommandHandler : IRequestHandler<RemoveAccountCommand, BaseCommandResult>
    {
        #region Fields

        private readonly IPostRepository _postRepository;
        private readonly ISessionUserService _sessionUserService;
        private readonly IIdentityService _identityService;
        private readonly IAccountRepository _accountRepository;
        private readonly IStorageService _storageService;

        #endregion

        #region Constructors
        
        public RemoveAccountCommandHandler(IPostRepository postRepository, ISessionUserService sessionUserService, IIdentityService identityService, IAccountRepository accountRepository, IStorageService storageService)
        {
            _postRepository = postRepository;
            _sessionUserService = sessionUserService;
            _identityService = identityService;
            _accountRepository = accountRepository;
            _storageService = storageService;
        }

        #endregion

        #region Public Methods

        public async Task<BaseCommandResult> Handle(RemoveAccountCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResult();
            var accountId = _sessionUserService.AccountId;
            var userId = _sessionUserService.UserId;

            await _postRepository.DeletePostAsync(accountId);
            await _identityService.DeleteAsync(userId);
            await _accountRepository.DeleteAsync(accountId);
            await _storageService.DeleteUserImagesAsync(ConfigurationConstant.AwsS3PostBucket, accountId);
            
            return response;
        }

        #endregion

    }
}