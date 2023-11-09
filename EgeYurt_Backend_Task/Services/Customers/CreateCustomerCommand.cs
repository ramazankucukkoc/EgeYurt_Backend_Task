using EgeYurt_Backend_Task.Authorization;
using EgeYurt_Backend_Task.DataAccess.Repositories.Abstract;
using EgeYurt_Backend_Task.Entities;
using MediatR;

namespace EgeYurt_Backend_Task.Services.Customers
{
    public class CreateCustomerCommand : IRequest<CreateCustomerDto>
        , ISecuredRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public string[] Roles => new[] { "Admin" };

        public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CreateCustomerDto>
        {
            private readonly ICustomerRepository _customerRepository;

            public CreateCustomerCommandHandler(ICustomerRepository customerRepository)
            {
                _customerRepository = customerRepository;
            }

            public async Task<CreateCustomerDto> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
            {
                if (request == null) throw new Exception("Data is empty !!!!");

                Customer customer = new()
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email,
                    Address = request.Address,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    IsDeleted = false
                };
                Customer addedCustomer = await _customerRepository.AddAsync(customer);
                CreateCustomerDto createCustomerDto = new CreateCustomerDto()
                { Id = addedCustomer.Id, Address = addedCustomer.Address, Email = addedCustomer.Email, FirstName = addedCustomer.FirstName, LastName = addedCustomer.LastName, IsDeleted = addedCustomer.IsDeleted };
                return createCustomerDto;
            }
        }
    }
}
