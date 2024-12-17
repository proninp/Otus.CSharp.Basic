namespace HomeWork09.Abstract;
public interface IReceiverService
{
    Task ReceiveAsync(CancellationToken stoppingToken);
}
