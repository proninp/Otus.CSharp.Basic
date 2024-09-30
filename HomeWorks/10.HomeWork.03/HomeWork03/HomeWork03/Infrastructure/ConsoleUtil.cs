namespace HomeWork03.Infrastructure;
public class ConsoleUtil
{
    public static void ClearCurrentConsoleLine(int lineTopPosition)
    {
        Console.SetCursorPosition(0, lineTopPosition);
        Console.Write(new string(' ', Console.WindowWidth));
        Console.SetCursorPosition(0, lineTopPosition);
    }

    public static void ClearBelow(int belowLineTop)
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

    public static void PrintConsole(string text, ConsoleColor color)
    {
        var currentColor = Console.ForegroundColor;
        Console.ForegroundColor = color;
        Console.WriteLine(text);
        Console.ForegroundColor = currentColor;
    }
}
