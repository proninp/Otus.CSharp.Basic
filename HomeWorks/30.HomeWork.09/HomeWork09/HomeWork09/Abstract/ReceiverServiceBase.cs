﻿using Microsoft.Extensions.Logging;
using Telegram.Bot;
using Telegram.Bot.Polling;

namespace HomeWork09.Abstract;
public abstract class ReceiverServiceBase<TUpdateHandler>(ITelegramBotClient botClient, TUpdateHandler updateHandler, ILogger<ReceiverServiceBase<TUpdateHandler>> logger)
    : IReceiverService where TUpdateHandler : IUpdateHandler
{
    public async Task ReceiveAsync(CancellationToken stoppingToken)
    {
        var receiverOptions = new ReceiverOptions() { DropPendingUpdates = true, AllowedUpdates = [] };

        var me = await botClient.GetMe(stoppingToken);
        logger.LogInformation("Start receiving updates for {BotName}", me.Username ?? "My Awesome Bot");

        await botClient.ReceiveAsync(updateHandler, receiverOptions, stoppingToken);
    }
}
