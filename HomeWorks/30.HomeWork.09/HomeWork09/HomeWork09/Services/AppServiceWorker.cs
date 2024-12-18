using Microsoft.Extensions.Hosting;

namespace HomeWork09.Services;
public class AppServiceWorker : BackgroundService
{
    private readonly AppService _appService;

    public AppServiceWorker(AppService appService)
    {
        _appService = appService;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await _appService.Run(stoppingToken);
    }
}