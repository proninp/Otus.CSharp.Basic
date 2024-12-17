using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace HomeWork09.Abstract;
public abstract class PollingServiceBase<TReceiverService>(IServiceProvider serviceProvider, ILogger logger)
    : BackgroundService where TReceiverService : IReceiverService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        logger.Information("Starting polling service");
        await DoWork(stoppingToken);
    }

    private async Task DoWork(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                using var scope = serviceProvider.CreateScope();
                var receiver = scope.ServiceProvider.GetRequiredService<TReceiverService>();
                await receiver.ReceiveAsync(stoppingToken);
            }
            catch (Exception ex)
            {
                logger.Error("Polling failed with exception: {Exception}", ex);
                // Cooldown if something goes wrong
                await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
            }
        }
    }
}
