using Binus.Flight.Core.Domain.AggregateRoots.Account;
using Binus.Flight.Core.Infrastructure.DataSources;

namespace Binus.Flight.Core.Infrastructure.Repositories.Common
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