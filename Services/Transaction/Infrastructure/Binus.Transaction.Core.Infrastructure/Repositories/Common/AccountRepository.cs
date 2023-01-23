using Binus.Transaction.Core.Domain.AggregateRoots.Account;
using Binus.Transaction.Core.Infrastructure.DataSources;

namespace Binus.Transaction.Core.Infrastructure.Repositories.Common
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