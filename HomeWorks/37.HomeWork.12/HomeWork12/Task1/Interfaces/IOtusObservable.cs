namespace Task1.Interfaces;
public interface IOtusObservable
{
    void AddObserver(IOtusObserver observer);

    void RemoveObserver(IOtusObserver observer);

    void Notify(string message);
}
