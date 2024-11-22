namespace HomeWork08.Abstractions;
public interface IEntityPrinter<T> : IPrinter
{
    public void ShowInfo(T? value);
}
