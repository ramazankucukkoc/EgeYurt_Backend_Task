using EgeYurt_Backend_Task.DataAccess.Repositories.Abstract;
using EgeYurt_Backend_Task.Entities;
using MediatR;

namespace EgeYurt_Backend_Task.Services
{
    public class GetAllCustomerQuery:IRequest<IList<Customer>>
    {
        public class GetAllCustomerQueryHandler : IRequestHandler<GetAllCustomerQuery, IList<Customer>>
        {
            private readonly ICustomerRepository _customerRepository;

            public GetAllCustomerQueryHandler(ICustomerRepository customerRepository)
            {
                _customerRepository = customerRepository;
            }

            public async Task<IList<Customer>> Handle(GetAllCustomerQuery request, CancellationToken cancellationToken)
            {
                var customers =  _customerRepository.GetList();
                if (customers == null) throw new Exception("List not found");

                return customers;
            }
        }

    }
}
