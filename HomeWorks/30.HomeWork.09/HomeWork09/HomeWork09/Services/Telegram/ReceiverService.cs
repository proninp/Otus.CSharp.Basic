using HomeWork09.Abstract;
using Serilog;
using Telegram.Bot;

namespace HomeWork09.Services.Telegram;
public class ReceiverService(
    ITelegramBotClient botClient,
    UpdateHandler updateHandler,
    IBotInfoProvider botInfoProvider,
    ILogger logger)
    : ReceiverServiceBase<UpdateHandler>(botClient, updateHandler, botInfoProvider, logger);
