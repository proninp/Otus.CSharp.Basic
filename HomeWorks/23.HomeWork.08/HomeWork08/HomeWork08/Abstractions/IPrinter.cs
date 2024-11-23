namespace HomeWork08.Abstractions;
public interface IPrinter
{
    void PrintTitle(string text);

    void Print(string text);

    void NewLine();

    string Prompt(string proptTitle, IEnumerable<string> choices);
}
