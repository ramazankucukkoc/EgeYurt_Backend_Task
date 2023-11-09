using EgeYurt_Backend_Task.DataAccess.Repositories.Abstract;
using EgeYurt_Backend_Task.Entities;
using MediatR;

namespace EgeYurt_Backend_Task.Services.Customers
{
    public class UpdateCustomerCommand:IRequest<UpdateCustomerCommandDto>
    {
        public int Id { get; set;}
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }

        public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, UpdateCustomerCommandDto>
        {
            private readonly ICustomerRepository _customerRepository;

            public UpdateCustomerCommandHandler(ICustomerRepository customerRepository)
            {
                _customerRepository = customerRepository;
            }

            public async Task<UpdateCustomerCommandDto> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
            {
                Customer? customer = await _customerRepository.GetAsync(c => c.Id == request.Id);
                if (customer == null) throw new ServiceException("Customer is empty");

                customer.Email = request.Email;
                customer.FirstName = request.FirstName;
                customer.LastName = request.LastName;
                customer.Address = request.Address;
                customer.UpdatedDate = DateTime.Now;
                customer.IsDeleted = request.IsDeleted;

                Customer updatedCustomer =await _customerRepository.UpdateAsync(customer);
                UpdateCustomerCommandDto updateCustomerCommandDto = new UpdateCustomerCommandDto()
                {
                    Id = updatedCustomer.Id,
                    Address = updatedCustomer.Address,
                    FirstName = updatedCustomer.FirstName,
                    LastName = updatedCustomer.LastName,
                    Email = updatedCustomer.Email,
                    IsDeleted = updatedCustomer.IsDeleted,
                };
                return updateCustomerCommandDto;
            }
        }
    }
}
