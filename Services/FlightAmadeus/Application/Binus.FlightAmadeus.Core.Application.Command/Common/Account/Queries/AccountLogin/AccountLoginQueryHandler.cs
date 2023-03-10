using System.Threading;
using System.Threading.Tasks;
using Binus.FlightAmadeus.Core.Application.Commons;
using Binus.FlightAmadeus.Core.Application.Services;
using Binus.FlightAmadeus.Core.Domain.AggregateRoots.Account;
using MediatR;

namespace Binus.FlightAmadeus.Core.Application.Command.Common.Account.Queries.AccountLogin
{
    public class AccountLoginQueryHandler : IRequestHandler<AccountLoginQuery, BaseQueryResult<AccountLoginDto>>
    {
        #region Fields

        private readonly IIdentityService _identityService;
        private readonly IAccountRepository _accountRepository;

        #endregion

        #region Constructors

        public AccountLoginQueryHandler(IIdentityService identityService, IAccountRepository accountRepository)
        {
            _identityService = identityService;
            _accountRepository = accountRepository;
        }

        #endregion

        #region Public Methods

        public async Task<BaseQueryResult<AccountLoginDto>> Handle(AccountLoginQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseQueryResult<AccountLoginDto>
            {
                Data = new AccountLoginDto()
            };

            var loginResponse = await _identityService.LoginAsync(request.Email, request.Password);
            
            if (!loginResponse.IsSuccess)
            {
                response.AddErrorMessages(loginResponse.ErrorMessages);
                return response;
            }

            response.Data.Token = loginResponse.Token;
            
            return response;
        }

        #endregion
        
    }
}