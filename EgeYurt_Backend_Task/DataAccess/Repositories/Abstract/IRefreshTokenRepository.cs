using EgeYurt_Backend_Task.DataAccess.EntityFramework;
using EgeYurt_Backend_Task.Entities;

namespace EgeYurt_Backend_Task.DataAccess.Repositories.Abstract
{
    public interface IRefreshTokenRepository:IEntityRepository<RefreshToken>
    {
    }
}
