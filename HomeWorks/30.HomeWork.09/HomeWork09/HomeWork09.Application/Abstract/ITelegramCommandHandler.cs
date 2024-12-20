using Telegram.Bot.Types;

namespace HomeWork09.Application.Abstract;
public interface ITelegramCommandHandler
{
    Task<Message?> Handle(Message message);
}
