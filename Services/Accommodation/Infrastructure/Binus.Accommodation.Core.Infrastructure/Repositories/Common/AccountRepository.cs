using Binus.Accommodation.Core.Domain.AggregateRoots.Account;
using Binus.Accommodation.Core.Infrastructure.DataSources;

namespace Binus.Accommodation.Core.Infrastructure.Repositories.Common
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