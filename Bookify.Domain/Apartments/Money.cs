namespace Bookify.Domain.Apartments;

public record Money(decimal Amount, Currency Currency)
{
   public static Money operator +(Money first, Money second)
   {
      if (first.Currency != second.Currency)
      {
          throw new InvalidOperationException("Cannot add money with different currencies");
      }
      return new Money(first.Amount + second.Amount, first.Currency);
   }

   public static Money Zero() => new(0, Currency.None);
}