namespace Bookify.Domain.Users;

public sealed class Role
{
    public static Role Registered => new(1, "Registered");
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;

    public Role(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public ICollection<User> Users { get; set; } = [];
}
