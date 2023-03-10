using Binus.DealsTourRadar.Core.Domain.AggregateRoots.Account;
using Binus.DealsTourRadar.Core.Infrastructure.DataSources;

namespace Binus.DealsTourRadar.Core.Infrastructure.Repositories.Common
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