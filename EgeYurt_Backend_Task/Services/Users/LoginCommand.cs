using EgeYurt_Backend_Task.DataAccess.Repositories.Abstract;
using EgeYurt_Backend_Task.DataAccess.Repositories.Concrete;
using EgeYurt_Backend_Task.Entities;
using EgeYurt_Backend_Task.Helpers;
using EgeYurt_Backend_Task.Security;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EgeYurt_Backend_Task.Services.Users
{
    public class LoginCommand : IRequest<LoginDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginDto>
        {
            private readonly IUserRepository _userRepository;
            private readonly ITokenHelper _tokenHelper;
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;
            private readonly IRefreshTokenRepository _refreshTokenRepository;

            public LoginCommandHandler(IUserRepository userRepository, ITokenHelper tokenHelper,
                IUserOperationClaimRepository userOperationClaimRepository, IRefreshTokenRepository refreshTokenRepository)
            {
                _userRepository = userRepository;
                _tokenHelper = tokenHelper;
                _userOperationClaimRepository = userOperationClaimRepository;
                _refreshTokenRepository = refreshTokenRepository;
            }

            public async Task<LoginDto> Handle(LoginCommand request, CancellationToken cancellationToken)
            {
                User? user = await _userRepository.GetAsync(u => u.Email == request.Email);
                if (user == null) throw new Exception("User Not Found");

                if (!HashingHelper.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt)) throw new Exception("Password is wrong !!!!");

                IList<OperationClaim> operationClaims = await _userOperationClaimRepository
             .Query()
             .AsNoTracking()
             .Where(p => p.UserId == user.Id)
             .Select(p => new OperationClaim { Id = p.OperationClaimId, Name = p.OperationClaim.Name })
             .ToListAsync();
                AccessToken createdAccessToken = _tokenHelper.CreateToken(user, operationClaims);
                RefreshToken createdRefreshToken = _tokenHelper.CreateRefreshToken(user);
                RefreshToken addedRefreshToken = await _refreshTokenRepository.AddAsync(createdRefreshToken);
                LoginDto loginDto = new()
                {
                    AccessToken = createdAccessToken,
                    RefreshToken = addedRefreshToken
                };
                return loginDto;

            }
        }
    }
}
