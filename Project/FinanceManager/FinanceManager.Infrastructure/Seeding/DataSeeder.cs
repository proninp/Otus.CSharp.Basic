using FinanceManager.Core.Models;

namespace FinanceManager.Infrastructure.Seeding;
public static class DataSeeder
{
    public static Currency[] GetCurrencySeeds()
    {
        return new[]
        {
            new Currency(currencyCode: "RUB", title: "Russian Ruble", currencySign: "₽"),
            new Currency(currencyCode: "BYN", title: "Belarusian Ruble", currencySign: "Br"),
            new Currency(currencyCode: "USD", title: "United States Dollar", currencySign: "$"),
            new Currency(currencyCode: "EUR", title: "Euro", currencySign: "€"),
            new Currency(currencyCode: "GBP", title: "British Pound Sterling", currencySign: "£"),
            new Currency(currencyCode: "TRY", title: "Turkish Lira", currencySign: "₺"),
        };
    }

    public static AccountType[] GetAccountTypeSeeds()
    {
        return new[]
        {
            new AccountType("Cash"),
            new AccountType("Debit/credit card"),
            new AccountType("Checking"),
            new AccountType("Loan"),
            new AccountType("Deposit"),
        };
    }
}
