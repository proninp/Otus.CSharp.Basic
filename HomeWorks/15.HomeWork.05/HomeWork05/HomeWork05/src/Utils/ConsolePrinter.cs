using HomeWork05.src.Abstractions;

namespace HomeWork05.src.Utils;
public class ConsolePrinter : IPrintable
{
    public void PrintTitle(string title)
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine($"********** {title} **********");
        Console.ResetColor();
    }

    public void PrintLine(string line)
    {
        Console.WriteLine(line);
    }

    public void PrintLine(string line, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        PrintLine(line);
        Console.ResetColor();
    }

    public void PrintLine<T>(IEnumerable<T> elements)
    {
        Console.WriteLine(string.Join(", ", elements));
    }

    public void PrintLinesSeparation()
    {
        Console.WriteLine();
        Console.WriteLine();
    }
}
