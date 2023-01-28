using Binus.Customer.Core.Domain.AggregateRoots.CustomerAggregate;
using Binus.Customer.Core.Domain.Commons;
using Binus.Services.Customer.API.ViewModels.CustomerViewModel;
using MediatR;

namespace Binus.Services.Customer.API.Controllers;

public class CustomersController : CrudController<Binus.Customer.Core.Domain.AggregateRoots.CustomerAggregate.Customer, CreateCustomerVm, UpdateCustomerVm>
{
    private readonly ICustomerRepository _customerRepository;
    
    public CustomersController(IMediator mediator, ICustomerRepository customerRepository) : base(mediator)
    {
        _customerRepository = customerRepository;
    }

    public override IBaseRepository<Binus.Customer.Core.Domain.AggregateRoots.CustomerAggregate.Customer> BaseRepository
        => _customerRepository;
}