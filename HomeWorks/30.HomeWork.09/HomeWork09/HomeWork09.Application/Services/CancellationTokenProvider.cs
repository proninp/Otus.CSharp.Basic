using HomeWork09.Application.Abstract;

namespace HomeWork09.Application.Services;
public sealed class CancellationTokenProvider : ICancellationTokenProvider
{
    private readonly CancellationTokenSource _cts = new();

    public CancellationToken Token => _cts.Token;

    public void Cancel() => _cts.Cancel();
}