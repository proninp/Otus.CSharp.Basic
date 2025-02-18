﻿namespace HomeWork09.Application.Abstract;
public interface IUpdateEventProvider
{
    public event Action<string>? OnHandleUpdateStarted;

    public event Action<string>? OnHandleUpdateCompleted;

    void RaiseUpdateStarted(string message);

    void RaiseUpdateCompleted(string message);
}
