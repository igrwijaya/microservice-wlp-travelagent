using Binus.Booking.Core.Application.Commons;
using MediatR;

namespace Binus.Booking.Core.Application.Command.Common.Account.Commands.CreateAccount
{
    public class CreateAccountCommand : IRequest<BaseCommandResult<string>>
    {
        #region Properties

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        #endregion
    }
}