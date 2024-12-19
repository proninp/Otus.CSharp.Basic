namespace HomeWork09.Application.Abstract;
public interface IPollingService
{
    Task DoWork(CancellationToken stoppingToken);
}
