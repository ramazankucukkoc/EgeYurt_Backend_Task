using EgeYurt_Backend_Task.DataAccess.EntityFramework;
using EgeYurt_Backend_Task.DataAccess.Repositories.Abstract;
using EgeYurt_Backend_Task.Entities;

namespace EgeYurt_Backend_Task.DataAccess.Repositories.Concrete
{
    public class OperationClaimRepository : EfEntityRepositoryBase<OperationClaim, AppDbContext>,IOperationClaimRepository
    {
        public OperationClaimRepository(AppDbContext context) : base(context)
        {
        }
    }
}
