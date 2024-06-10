using Bookify.Domain.Users;

namespace Bookify.Domain.UnitTests.Users;

internal static class UserData
{
    public static readonly FirstName FirstName = new("John");
    public static readonly LastName LastName = new("Doe");
    public static readonly Email Email = new("john.doe@test.com");
}
