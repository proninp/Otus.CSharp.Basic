namespace HomeWork09.Abstract;
public interface ICancellationTokenProvider
{
    CancellationToken Token { get; }

    void Cancel();
}
