using Binus.AccommodationAgoda.Core.Domain.AggregateRoots.Account;
using Binus.AccommodationAgoda.Core.Infrastructure.DataSources;

namespace Binus.AccommodationAgoda.Core.Infrastructure.Repositories.Common
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