
using System.Security.Claims;
using Bookify.Application.Abstractions.Authentication;
using Microsoft.AspNetCore.Http;

namespace Bookify.Infrastructure.Authentication;

internal sealed class UserContext : IUserContext
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserContext(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public Guid UserId =>
            _httpContextAccessor
            .HttpContext?
            .User
            .GetUserId()
        ?? throw new ApplicationException("User is not authenticated");

    public string IdentityId =>
        _httpContextAccessor
            .HttpContext?
            .User
            .GetIdentityId()
        ?? throw new ApplicationException("User is not authenticated");
}
