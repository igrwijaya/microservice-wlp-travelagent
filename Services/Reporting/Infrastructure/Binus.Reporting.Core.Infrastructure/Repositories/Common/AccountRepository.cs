using Binus.Customer.Core.Domain.AggregateRoots.Account;
using Binus.Customer.Core.Infrastructure.DataSources;

namespace Binus.Customer.Core.Infrastructure.Repositories.Common
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