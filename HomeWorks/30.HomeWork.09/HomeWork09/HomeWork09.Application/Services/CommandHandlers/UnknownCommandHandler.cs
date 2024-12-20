using HomeWork09.Application.Abstract;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace HomeWork09.Application.Services.CommandHandlers;
public sealed class UnknownCommandHandler : ITelegramCommandHandler
{
    private readonly ITelegramBotClient _botClient;

    public UnknownCommandHandler(ITelegramBotClient botClient)
    {
        _botClient = botClient;
    }

    public async Task<Message?> Handle(Message message)
    {
        var echo = $"Сообщение успешно принято: '{message.Text}'";
        var sentMessage = await _botClient.SendMessage(message.Chat, echo, parseMode: ParseMode.Html,
            replyMarkup: new ReplyKeyboardRemove());
        return sentMessage;
    }
}
