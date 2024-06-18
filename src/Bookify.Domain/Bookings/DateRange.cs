namespace Bookify.Domain.Bookings;

public record DateRange
{
    public DateOnly Start { get; init; }
    public DateOnly End { get; init; }

    private DateRange()
    {
    }

    public int LengthInDays => End.DayNumber - Start.DayNumber;

    public static DateRange Create(DateOnly start, DateOnly end)
    {
        if (start > end)
        {
            throw new ApplicationException("End date precedes start date.");
        }

        return new DateRange
        {
            Start = start,
            End = end
        };
    }
}