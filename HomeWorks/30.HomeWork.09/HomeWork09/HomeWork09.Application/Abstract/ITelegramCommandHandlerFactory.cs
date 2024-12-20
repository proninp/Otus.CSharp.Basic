using Telegram.Bot.Types;

namespace HomeWork09.Application.Abstract;
public interface ITelegramCommandHandlerFactory
{
    ITelegramCommandHandler GetResponseHandler(string message);
}
