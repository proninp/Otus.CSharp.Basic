using HomeWork09.Application.Abstract;

namespace HomeWork09.Application.Services;
public sealed class UpdateEventProvider : IUpdateEventProvider
{
    public event Action<string>? OnHandleUpdateStarted;
    public event Action<string>? OnHandleUpdateCompleted;

    public void RaiseUpdateStarted(string message)
    {
        OnHandleUpdateStarted?.Invoke(message);
    }

    public void RaiseUpdateCompleted(string message)
    {
        OnHandleUpdateCompleted?.Invoke(message);
    }
}
