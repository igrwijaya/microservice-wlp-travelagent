using Binus.Deals.Core.Domain.AggregateRoots.Account;
using Binus.Deals.Core.Infrastructure.DataSources;

namespace Binus.Deals.Core.Infrastructure.Repositories.Common
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