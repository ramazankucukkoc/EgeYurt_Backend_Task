using EgeYurt_Backend_Task.DataAccess.Repositories.Abstract;
using EgeYurt_Backend_Task.Entities;
using MediatR;

namespace EgeYurt_Backend_Task.Services.Customers
{
    public class DeleteCustomerCommand:IRequest<DeleteCustomerCommandDto>
    {
        public int Id { get; set; }

        public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, DeleteCustomerCommandDto>
        {
            private readonly ICustomerRepository _customerRepository;

            public DeleteCustomerCommandHandler(ICustomerRepository customerRepository)
            {
                _customerRepository = customerRepository;
            }
            public async Task<DeleteCustomerCommandDto> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
            {
                Customer? customer = await _customerRepository.GetAsync(c => c.Id == request.Id);
                if (customer == null) throw new ServiceException("Customer is empty");

                customer.IsDeleted = true;
                Customer deletedCustomer = await _customerRepository.UpdateAsync(customer);
                DeleteCustomerCommandDto deleteCustomerCommandDto = new()
                {
                    LastName = deletedCustomer.LastName,
                    Address = deletedCustomer.Address,
                    Email = deletedCustomer.Email,
                    FirstName = deletedCustomer.FirstName,
                    Id = deletedCustomer.Id,
                    IsDeleted=deletedCustomer.IsDeleted,
                };
                return deleteCustomerCommandDto;
            }
        }

    }
}
