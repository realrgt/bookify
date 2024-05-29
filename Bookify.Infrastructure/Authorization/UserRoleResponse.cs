using Bookify.Domain.Users;

namespace Bookify.Infrastructure.Authorization;

public sealed class UserRoleResponse
{
    public Guid Id { get; init; }
    public List<Role> Roles { get; init; } = [];  
}
