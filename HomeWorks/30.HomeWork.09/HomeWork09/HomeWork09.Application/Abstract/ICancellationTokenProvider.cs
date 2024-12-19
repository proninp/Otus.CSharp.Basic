namespace HomeWork09.Application.Abstract;
public interface ICancellationTokenProvider
{
    CancellationToken Token { get; }

    void Cancel();
}
