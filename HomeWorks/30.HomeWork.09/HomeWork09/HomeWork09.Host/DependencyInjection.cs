﻿using HomeWork09.Application.Abstract;
using HomeWork09.Application.Injection;
using HomeWork09.Application.Options;
using HomeWork09.Application.Services;
using HomeWork09.Application.Services.CommandHandlers;
using HomeWork09.Application.Services.Telegram;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HomeWork09.Host;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .Configure<AppSettings>(configuration.GetSection(nameof(AppSettings)))
            .AddTelegram(configuration)
            .AddScoped<UpdateHandler>()
            .AddScoped<IReceiverService, ReceiverService>()
            .AddScoped<IPollingService, PollingService>()
            .AddScoped<ITelegramCommandHandlerFactory, TelegramCommandHandlerFactory>()
            .AddScoped<UnknownCommandHandler>()
            .AddScoped<CatFactCommandHandler>()
            .AddScoped<ICatFactService, CatFactService>()
            .AddSingleton<IUpdateEventProvider, UpdateEventProvider>()
            .AddSingleton<ICancellationTokenProvider, CancellationTokenProvider>()
            .AddSingleton<IBotInfoProvider, BotInfoProvider>()
            .AddScoped<IBotManager, BotManager>()
            .AddHostedService<BotInitializer>()
            .AddHttpClient();
    }
}
