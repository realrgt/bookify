using Bookify.Domain.Users;

namespace Bookify.Application.UnitTests;

internal static class UserData
{
    public static User Create() => User.Create(FirstName, LastName, Email);

    public static readonly FirstName FirstName = new("John");
    public static readonly LastName LastName = new("Doe");
    public static readonly Email Email = new("john.doe@test.com");
}
