using Bookify.Domain.Abstractions;

namespace Boofify.Domain.Bookings.Events;

public sealed record BookingReservedDomainEvent(Guid bookingId) : IDomainEvent;