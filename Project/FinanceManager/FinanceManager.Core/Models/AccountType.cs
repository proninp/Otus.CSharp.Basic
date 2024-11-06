using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FinanceManager.Core.Models;
public class AccountType
{
    public short Id { get; set; }

    public required string Name { get; set; }
}
