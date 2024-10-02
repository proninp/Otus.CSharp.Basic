using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HomeWork03.Services;
public class ConsoleHelper
{
    public int Position { get => Console.CursorTop; }

    public void ClearCurrentLine(int lineTopPosition)
    {
        Console.SetCursorPosition(0, lineTopPosition);
        Console.Write(new string(' ', Console.WindowWidth));
        Console.SetCursorPosition(0, lineTopPosition);
    }

    public void ClearBelow(int belowLineTop)
    {
        int originalLeft = Console.CursorLeft;
        int originalTop = Console.CursorTop;

        for (int i = belowLineTop + 1; i < Console.WindowHeight; i++)
        {
            Console.SetCursorPosition(0, i);
            Console.Write(new string(' ', Console.WindowWidth));
        }
        Console.SetCursorPosition(originalLeft, originalTop);
    }

    public void NewLine() =>
        Console.WriteLine();

    public void SetToPosition(int topPosition) =>
        Console.SetCursorPosition(0, topPosition);

    public void PrintLine(string text) =>
        PrintLine(text, Console.CursorTop);

    public void PrintLine(string text, int lineTopPosition)
    {
        ClearCurrentLine(lineTopPosition);
        Console.WriteLine(text);
    }

    public void PrintConsoleSpecial(string text)
    {
        PrintConsole(text, ConsoleColor.Magenta);
    }

    public void PrintConsoleError(string text)
    {
        PrintConsole(text, ConsoleColor.Red);
    }

    public void PrintConsole(string text, ConsoleColor color)
    {
        var currentColor = Console.ForegroundColor;
        Console.ForegroundColor = color;
        Console.WriteLine(text);
        Console.ForegroundColor = currentColor;
    }

    public void PrintConsoleWithBackGround(ConsoleColor color, string message)
    {
        Console.BackgroundColor = color;
        Console.WriteLine(message);
        Console.ResetColor();
    }
}
