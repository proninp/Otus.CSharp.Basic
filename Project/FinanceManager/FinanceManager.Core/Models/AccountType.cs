using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FinanceManager.Core.Models;
public class AccountType
{
    public int Id { get; init; }

    public string Name { get; init; }

    public AccountType(string name)
    {
        Name = name;
    }
}
