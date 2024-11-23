namespace HomeWork08.Abstractions;
public interface IEntityPrinter<T> : IPrinter
{
    void ShowInfo(T? value);
}
