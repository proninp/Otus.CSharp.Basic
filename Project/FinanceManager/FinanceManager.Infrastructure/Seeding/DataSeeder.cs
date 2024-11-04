using FinanceManager.Core.Models;

namespace FinanceManager.Infrastructure.Seeding;
public static class DataSeeder
{
    public static Currency[] GetCurrencySeeds()
    {
        return
        [
            new Currency() { CurrencyCode = "RUB", Title = "Russian Ruble", CurrencySign = "₽" },
            new Currency() { CurrencyCode = "BYN", Title = "Belarusian Ruble", CurrencySign = "Br" },
            new Currency() { CurrencyCode = "USD", Title = "United States Dollar", CurrencySign = "$" },
            new Currency() { CurrencyCode = "EUR", Title = "Euro", CurrencySign = "€" },
            new Currency() { CurrencyCode = "GBP", Title = "British Pound Sterling", CurrencySign = "£" },
            new Currency() { CurrencyCode = "TRY", Title = "Turkish Lira", CurrencySign = "₺" }
        ];
    }
}
