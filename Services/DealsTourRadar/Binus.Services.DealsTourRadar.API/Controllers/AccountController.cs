using System.Threading.Tasks;
using Binus.DealsTourRadar.Core.Application.Command.Common.Account.Commands.CreateAccount;
using Binus.DealsTourRadar.Core.Application.Command.Common.Account.Commands.RemoveAccount;
using Binus.DealsTourRadar.Core.Application.Command.Common.Account.Queries.AccountLogin;
using Binus.DealsTourRadar.Core.Application.Commons;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Binus.Services.DealsTourRadar.API.Controllers
{
    public class AccountController : BaseController
    {
        #region Constructors

        public AccountController(IMediator mediator) : base(mediator)
        {
        }

        #endregion

        #region APIs

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<BaseCommandResult<string>>> Register(CreateAccountCommand command)
        {
            return await Mediator.Send(command);
        }
        
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<BaseQueryResult<AccountLoginDto>>> Login(AccountLoginQuery query)
        {
            return await Mediator.Send(query);
        }
        
        [HttpPost]
        public async Task<ActionResult<BaseCommandResult>> Remove()
        {
            return await Mediator.Send(new RemoveAccountCommand());
        }

        #endregion
    }
}