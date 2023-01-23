using Binus.Partner.Core.Domain.AggregateRoots.Account;
using Binus.Partner.Core.Infrastructure.DataSources;

namespace Binus.Partner.Core.Infrastructure.Repositories.Common
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