namespace FinanceManager.Core.Models;
public class Currency
{
    public short Id { get; }

    public string Title { get; }

    public string CurrencyCode { get; }

    public string CurrencySign { get; }

    public Currency(string title, string currencyCode, string currencySign)
    {
        Title = title;
        CurrencyCode = currencyCode;
        CurrencySign = currencySign;
    }
}