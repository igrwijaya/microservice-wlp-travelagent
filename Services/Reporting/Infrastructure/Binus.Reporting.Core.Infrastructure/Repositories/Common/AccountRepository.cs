using Binus.Reporting.Core.Domain.AggregateRoots.Account;
using Binus.Reporting.Core.Infrastructure.DataSources;

namespace Binus.Reporting.Core.Infrastructure.Repositories.Common
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