using EgeYurt_Backend_Task.DataAccess.Repositories.Abstract;
using EgeYurt_Backend_Task.Entities;
using EgeYurt_Backend_Task.Helpers;
using EgeYurt_Backend_Task.Security;
using MediatR;

namespace EgeYurt_Backend_Task.Services.Users
{
    public class RegisterCommand : IRequest<RegisteredDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisteredDto>
        {
            private readonly IUserRepository _userRepository;
            private readonly ITokenHelper _tokenHelper;
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;
            private readonly IRefreshTokenRepository    _refreshTokenRepository;
            public RegisterCommandHandler(IUserRepository userRepository, ITokenHelper tokenHelper, 
                IUserOperationClaimRepository userOperationClaimRepository, IRefreshTokenRepository refreshTokenRepository)
            {
                _userRepository = userRepository;
                _tokenHelper = tokenHelper;
                _userOperationClaimRepository = userOperationClaimRepository;
                _refreshTokenRepository = refreshTokenRepository;
            }
            public async Task<RegisteredDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
            {
                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);
                User newUser = new()
                {
                    Email = request.Email,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    IsDeleted = false,
                    FirstName = request.FirstName,
                    LastName = request.LastName
                };
                User createUser = await _userRepository.AddAsync(newUser);
               
                IList<UserOperationClaim> userOperationClaims = _userOperationClaimRepository.GetList(u => u.UserId == createUser.Id);
                IList<OperationClaim> operationClaims = userOperationClaims.Select(u => new OperationClaim
                {
                    Id = u.OperationClaimId,
                    Name = u.OperationClaim.Name
                }).ToArray();

                AccessToken createdAccessToken = _tokenHelper.CreateToken(createUser,operationClaims);
                RefreshToken createdRefreshToken = _tokenHelper.CreateRefreshToken(createUser);
                RefreshToken addedRefreshToken = await _refreshTokenRepository.AddAsync(createdRefreshToken);
                RegisteredDto registeredDto = new()
                {
                    AccessToken = createdAccessToken,
                    RefreshToken = addedRefreshToken
                };
                return registeredDto;
            }

        }
    }
}
