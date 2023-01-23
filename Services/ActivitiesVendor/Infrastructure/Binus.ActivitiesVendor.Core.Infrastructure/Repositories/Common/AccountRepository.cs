using Binus.ActivitiesVendor.Core.Domain.AggregateRoots.Account;
using Binus.ActivitiesVendor.Core.Infrastructure.DataSources;

namespace Binus.ActivitiesVendor.Core.Infrastructure.Repositories.Common
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