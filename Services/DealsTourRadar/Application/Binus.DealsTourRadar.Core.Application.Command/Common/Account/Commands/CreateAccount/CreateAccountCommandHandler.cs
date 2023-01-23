using System.Threading;
using System.Threading.Tasks;
using Binus.DealsTourRadar.Core.Application.Commons;
using Binus.DealsTourRadar.Core.Application.Services;
using Binus.DealsTourRadar.Core.Domain.AggregateRoots.Account;
using MediatR;

namespace Binus.DealsTourRadar.Core.Application.Command.Common.Account.Commands.CreateAccount
{
    public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, BaseCommandResult<string>>
    {
        #region Fields

        private readonly IIdentityService _identityService;
        private readonly IAccountRepository _accountRepository;

        #endregion

        #region Constructors

        public CreateAccountCommandHandler(IIdentityService identityService, IAccountRepository accountRepository)
        {
            _identityService = identityService;
            _accountRepository = accountRepository;
        }

        #endregion

        #region Public Methods

        public async Task<BaseCommandResult<string>> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResult<string>();
            var account = new DealsTourRadar.Core.Domain.AggregateRoots.Account.Account(request.Name);

            await _accountRepository.CreateAsync(account);
            
            var identityResponse = await _identityService.CreateAsync(account.Id, request.Email, request.Password);

            if (!identityResponse.IsSuccess)
            {
                response.AddErrorMessages(identityResponse.ErrorMessages);
                return response;
            }

            response.Data = identityResponse.UserId;

            return response;
        }

        #endregion
        
    }
}