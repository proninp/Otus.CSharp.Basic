using HomeWork09.Application.Abstract;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace HomeWork09.Application.Services.CommandHandlers;
public sealed class CatFactCommandHandler : ITelegramCommandHandler
{
    private readonly ITelegramBotClient _botClient;
    private readonly ICatFactService _catFactService;

    public CatFactCommandHandler(ICatFactService catFactService, ITelegramBotClient botClient)
    {
        _catFactService = catFactService;
        _botClient = botClient;
    }

    public async Task<Message?> Handle(Message message)
    {
        var fact = await _catFactService.GetCatFactAsync();
        var sentMessage = await _botClient.SendMessage(message.Chat, fact, parseMode: ParseMode.Html,
            replyMarkup: new ReplyKeyboardRemove());
        return sentMessage;
    }
}
