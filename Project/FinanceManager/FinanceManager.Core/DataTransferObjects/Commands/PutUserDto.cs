using FinanceManager.Core.Models;

namespace FinanceManager.Core.DataTransferObjects.Commands;
public class PutUserDto
{
    public long Id { get; init; }

    public long TelegramId { get; init; }

    public string? Name { get; init; }
}
