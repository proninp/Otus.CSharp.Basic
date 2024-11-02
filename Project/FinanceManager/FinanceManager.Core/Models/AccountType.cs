using System.ComponentModel;

namespace FinanceManager.Core.Models;
public enum AccountType
{
    [Description("Cash")]
    Cash,
    [Description("Debit/credit card")]
    DebitСreditСard,
    [Description("Checking")]
    Checking,
    [Description("Loan")]
    Loan,
    [Description("Deposit")]
    Deposit
}
