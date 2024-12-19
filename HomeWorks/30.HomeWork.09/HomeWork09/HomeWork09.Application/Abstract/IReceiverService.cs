namespace HomeWork09.Application.Abstract;
public interface IReceiverService
{
    Task ReceiveAsync(CancellationToken stoppingToken);
}
