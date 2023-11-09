using EgeYurt_Backend_Task.DataAccess.EntityFramework;
using EgeYurt_Backend_Task.DataAccess.Repositories.Abstract;
using EgeYurt_Backend_Task.Entities;

namespace EgeYurt_Backend_Task.DataAccess.Repositories.Concrete
{
    public class CustomerRepository : EfEntityRepositoryBase<Customer, AppDbContext>, ICustomerRepository
    {
        public CustomerRepository(AppDbContext context) : base(context)
        {
        }
    }
}
