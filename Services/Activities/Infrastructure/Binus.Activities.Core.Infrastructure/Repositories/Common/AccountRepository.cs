using Binus.Activities.Core.Domain.AggregateRoots.Account;
using Binus.Activities.Core.Infrastructure.DataSources;

namespace Binus.Activities.Core.Infrastructure.Repositories.Common
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