﻿using EgeYurt_Backend_Task.Extensions;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace EgeYurt_Backend_Task.Authorization
{
    public class AuthorizationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>, ISecuredRequest
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AuthorizationBehavior(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            List<string>? userRoleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();

            if (userRoleClaims == null)
                throw new AuthorizationException("You are not authenticated.");

            bool isNotMatchedAUserRoleClaimWithRequestRoles = userRoleClaims
                .FirstOrDefault(
                    userRoleClaim => userRoleClaim == GeneralOperationClaims.Admin || request.Roles.Any(role => role == userRoleClaim)
                )
                .IsNullOrEmpty();
            if (isNotMatchedAUserRoleClaimWithRequestRoles)
                throw new AuthorizationException("You are not authorized.");

            TResponse response = await next();
            return response;
        }
    }
}
