namespace Bookify.Domain.Shared;

public record Currency
{
    internal static Currency None = new("");
    public static Currency Usd = new("USD");
    public static Currency Eur = new("EUR");
    public static Currency Mzn = new("MZN");
    
    private Currency(string code) => Code = code;
    public string Code { get; init; }

    public static Currency FromCode(string code)
    {
        return All.FirstOrDefault(c => c.Code == code) ?? 
            throw new ApplicationException("The currency code is invalid");   
    }

    public static readonly IReadOnlyCollection<Currency> All = [Usd, Eur, Mzn];
}