﻿namespace FinanceManager.Core.Models;
public class Currency
{
    public int Id { get; init; }

    public string Title { get; init; }

    public string CurrencyCode { get; init; }

    public string CurrencySign { get; init; }

    public Currency(string title, string currencyCode, string currencySign)
    {
        Title = title;
        CurrencyCode = currencyCode;
        CurrencySign = currencySign;
    }
}