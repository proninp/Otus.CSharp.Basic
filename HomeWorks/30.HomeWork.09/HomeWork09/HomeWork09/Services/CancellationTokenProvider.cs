using HomeWork09.Abstract;

namespace HomeWork09.Services;
public class CancellationTokenProvider : ICancellationTokenProvider
{
    private readonly CancellationTokenSource _cts = new();

    public CancellationToken Token => _cts.Token;

    public void Cancel() => _cts.Cancel();
}
