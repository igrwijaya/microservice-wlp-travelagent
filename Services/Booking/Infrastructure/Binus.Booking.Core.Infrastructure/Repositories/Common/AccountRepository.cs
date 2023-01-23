using Binus.Booking.Core.Domain.AggregateRoots.Account;
using Binus.Booking.Core.Infrastructure.DataSources;

namespace Binus.Booking.Core.Infrastructure.Repositories.Common
{
    public class AccountRepository : BaseRepository<Account>, IAccountRepository
    {
        #region Constructors

        public AccountRepository(CoreDbContext context) : base(context)
        {
        }

        #endregion
    }
}