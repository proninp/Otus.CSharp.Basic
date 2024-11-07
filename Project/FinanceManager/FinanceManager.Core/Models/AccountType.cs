using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FinanceManager.Core.Models;
public class AccountType
{
    public short Id { get; }

    public string Name { get; }

    public AccountType(string name)
    {
        Name = name;
    }
}
