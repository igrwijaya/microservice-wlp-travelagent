using Binus.Customer.Core.Domain.AggregateRoots.CustomerAggregate;
using Binus.Customer.Core.Infrastructure.DataSources;

namespace Binus.Customer.Core.Infrastructure.Repositories;

public class CustomerRepository : BaseRepository<Domain.AggregateRoots.CustomerAggregate.Customer>, ICustomerRepository
{
    public CustomerRepository(CoreDbContext context) : base(context)
    {
    }
}