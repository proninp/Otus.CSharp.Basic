namespace HomeWork08.Abstractions;
public interface IInputService
{
    string Prompt(string text);

    string Prompt(string promptTitle, IEnumerable<string> choices);

    T Ask<T>(string question);
}
