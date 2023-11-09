using EgeYurt_Backend_Task.Entities;

namespace EgeYurt_Backend_Task.Security
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, IList<OperationClaim> operationClaims);
        RefreshToken CreateRefreshToken(User user, string ipAddress);

    }
}
