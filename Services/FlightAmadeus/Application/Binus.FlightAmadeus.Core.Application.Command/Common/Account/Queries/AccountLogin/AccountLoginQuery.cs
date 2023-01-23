using Binus.FlightAmadeus.Core.Application.Commons;
using MediatR;

namespace Binus.FlightAmadeus.Core.Application.Command.Common.Account.Queries.AccountLogin
{
    public class AccountLoginQuery : IRequest<BaseQueryResult<AccountLoginDto>>
    {
        #region Properties

        public string Email { get; set; }

        public string Password { get; set; }

        #endregion
    }
}