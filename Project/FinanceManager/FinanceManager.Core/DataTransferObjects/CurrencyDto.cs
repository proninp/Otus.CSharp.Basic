using FinanceManager.Core.Models;

namespace FinanceManager.Core.DataTransferObjects;
public class CurrencyDto
{
    public short Id { get; set; }

    public string Title { get; set; }

    public string CurrencyCode { get; set; }

    public string CurrencySign { get; set; }
}

public static class CurrencyMappings
{
    public static CurrencyDto ToDto(this Currency currency)
    {
        return new CurrencyDto
        {
            Id = currency.Id,
            Title = currency.Title,
            CurrencyCode = currency.CurrencyCode,
            CurrencySign = currency.CurrencySign
        };
    }
}