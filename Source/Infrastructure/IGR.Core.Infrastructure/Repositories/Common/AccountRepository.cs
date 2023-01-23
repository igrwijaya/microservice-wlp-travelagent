using IGR.Core.Domain.AggregateRoots.Account;
using IGR.Core.Infrastructure.DataSources;

namespace IGR.Core.Infrastructure.Repositories.Common
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