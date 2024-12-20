using HomeWork09.Application.Abstract;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HomeWork09.Host;
public sealed class BotInitializer : BackgroundService
{
    private readonly IServiceProvider _services;
    private readonly ICancellationTokenProvider _tokenProvider;

    public BotInitializer(IServiceProvider services, ICancellationTokenProvider tokenProvider)
    {
        _services = services;
        _tokenProvider = tokenProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var scope = _services.CreateScope();
        var pollingService = scope.ServiceProvider.GetRequiredService<IPollingService>();
        await pollingService.DoWork(_tokenProvider.Token);
    }
}