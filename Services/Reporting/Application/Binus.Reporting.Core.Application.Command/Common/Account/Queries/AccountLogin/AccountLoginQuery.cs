using Binus.Reporting.Core.Application.Commons;
using MediatR;

namespace Binus.Reporting.Core.Application.Command.Common.Account.Queries.AccountLogin
{
    public class AccountLoginQuery : IRequest<BaseQueryResult<AccountLoginDto>>
    {
        #region Properties

        public string Email { get; set; }

        public string Password { get; set; }

        #endregion
    }
}