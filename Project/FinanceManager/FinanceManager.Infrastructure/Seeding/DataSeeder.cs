using FinanceManager.Core.Models;

namespace FinanceManager.Infrastructure.Seeding;
public static class DataSeeder
{
    public static Currency[] GetCurrencySeeds()
    {
        return new[]
        {
            new Currency(currencyCode: "RUB", title: "Russian Ruble", currencySign: "₽") { Id = 1 },
            new Currency(currencyCode: "BYN", title: "Belarusian Ruble", currencySign: "Br") { Id = 2 },
            new Currency(currencyCode: "USD", title: "United States Dollar", currencySign: "$") { Id = 3 },
            new Currency(currencyCode: "EUR", title: "Euro", currencySign: "€") { Id = 4 },
            new Currency(currencyCode: "GBP", title: "British Pound Sterling", currencySign: "£") { Id = 5 },
            new Currency(currencyCode: "TRY", title: "Turkish Lira", currencySign: "₺") { Id = 6 },
        };
    }

    public static AccountType[] GetAccountTypeSeeds()
    {
        return new[]
        {
            new AccountType("Cash") { Id = 1 },
            new AccountType("Debit/credit card") { Id = 2 },
            new AccountType("Checking") { Id = 3 },
            new AccountType("Loan") { Id = 4 },
            new AccountType("Deposit") { Id = 5 },
        };
    }
}
