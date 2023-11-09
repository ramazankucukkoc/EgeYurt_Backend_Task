using EgeYurt_Backend_Task.DataAccess.EntityFramework;
using EgeYurt_Backend_Task.DataAccess.Repositories.Abstract;
using EgeYurt_Backend_Task.Entities;

namespace EgeYurt_Backend_Task.DataAccess.Repositories.Concrete
{
    public class RefreshTokenRepository : EfEntityRepositoryBase<RefreshToken, AppDbContext>,IRefreshTokenRepository
    {
        public RefreshTokenRepository(AppDbContext context) : base(context)
        {
        }
    }
}
