using HomeWork09.Application.Abstract;
using Serilog;
using Telegram.Bot;

namespace HomeWork09.Application.Services.Telegram;
public sealed class ReceiverService(
    ITelegramBotClient botClient,
    UpdateHandler updateHandler,
    IBotInfoProvider botInfoProvider,
    ILogger logger)
    : ReceiverServiceBase<UpdateHandler>(botClient, updateHandler, botInfoProvider, logger);
