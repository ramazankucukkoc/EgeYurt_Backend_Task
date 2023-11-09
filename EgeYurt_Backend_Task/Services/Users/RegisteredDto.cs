using EgeYurt_Backend_Task.Entities;
using EgeYurt_Backend_Task.Security;

namespace EgeYurt_Backend_Task.Services.Users
{
    public class RegisteredDto
    {
        public AccessToken AccessToken { get; set; }
        public RefreshToken RefreshToken { get; set; }
    }
}
