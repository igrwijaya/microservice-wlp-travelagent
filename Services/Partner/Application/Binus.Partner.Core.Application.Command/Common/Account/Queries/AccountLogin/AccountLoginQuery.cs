using Binus.Partner.Core.Application.Commons;
using MediatR;

namespace Binus.Partner.Core.Application.Command.Common.Account.Queries.AccountLogin
{
    public class AccountLoginQuery : IRequest<BaseQueryResult<AccountLoginDto>>
    {
        #region Properties

        public string Email { get; set; }

        public string Password { get; set; }

        #endregion
    }
}