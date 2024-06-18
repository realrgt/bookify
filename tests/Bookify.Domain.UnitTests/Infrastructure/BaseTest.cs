using Bookify.Domain.Abstractions;

namespace Bookify.Domain.UnitTests;

public abstract class BaseTest
{
    public static T AssertDomainEventWasPublished<T>(Entity entity)
    {
        var domainEvent = entity.GetDomainEvents()
            .OfType<T>()
            .SingleOrDefault();

        if (domainEvent == null)
        {
            throw new Exception($"{typeof(T).Name} was not published.");
        }

        return domainEvent;
    }
}
