using Bookify.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Bookify.Infrastructure.Authorization;

internal sealed class AuthorizationService
{
    private readonly ApplicationDbContext _dbContext;

    public AuthorizationService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<UserRoleResponse> GetRolesForUserAsync(string identityId)
    {
        return await _dbContext.Set<User>()
            .Where(user => user.IdentityId == identityId)
            .Select(user => new UserRoleResponse
            {
                Id = user.Id,
                Roles = user.Roles.ToList()
            })
            .FirstAsync();
    }

    public async Task<HashSet<string>> GetPermissionsForUserAsync(string identityId)
    {
        var permissions = await _dbContext.Set<User>()
            .Where(user => user.IdentityId == identityId)
            .SelectMany(user => user.Roles.Select(role => role.Permissions))
            .FirstAsync();
        
        return permissions.Select(permission => permission.Name).ToHashSet();
    }
}
