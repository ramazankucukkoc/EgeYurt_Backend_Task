using EgeYurt_Backend_Task.Authorization;
using EgeYurt_Backend_Task.DataAccess.Repositories.Abstract;
using EgeYurt_Backend_Task.Entities;
using MediatR;

namespace EgeYurt_Backend_Task.Services.Customers
{
    public class GetAllCustomerQuery : IRequest<IList<Customer>>
        , ISecuredRequest
    {
        public string[] Roles => new[] { "Admin" };

        public class GetAllCustomerQueryHandler : IRequestHandler<GetAllCustomerQuery, IList<Customer>>
        {
            private readonly ICustomerRepository _customerRepository;

            public GetAllCustomerQueryHandler(ICustomerRepository customerRepository)
            {
                _customerRepository = customerRepository;
            }

            public async Task<IList<Customer>> Handle(GetAllCustomerQuery request, CancellationToken cancellationToken)
            {
                var customers =await _customerRepository.GetList(c=>!c.IsDeleted);
                if (customers == null) throw new Exception("List not found");

                return customers;
            }
        }

    }
}
