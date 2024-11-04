using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceManager.Core.Models;
public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public long TelegramId { get; set; }

    public ICollection<Account>? Accounts { get; set; }

    public ICollection<Category>? Categories { get; set; }
}
