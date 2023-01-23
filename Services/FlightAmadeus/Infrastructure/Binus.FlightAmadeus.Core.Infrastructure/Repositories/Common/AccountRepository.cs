using Binus.FlightAmadeus.Core.Domain.AggregateRoots.Account;
using Binus.FlightAmadeus.Core.Infrastructure.DataSources;

namespace Binus.FlightAmadeus.Core.Infrastructure.Repositories.Common
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