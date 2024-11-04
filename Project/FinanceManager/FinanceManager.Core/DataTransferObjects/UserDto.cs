namespace FinanceManager.Core.DataTransferObjects;
public class UserDto
{
    public long Id { get; set; }

    public string Name { get; set; }

    public long TelegramId { get; set; }
}

public static class UserMappings
{
    public static UserDto ToDto(this UserDto user)
    {
        return new UserDto() { Id = user.Id, Name = user.Name, TelegramId = user.TelegramId };
    }
}
