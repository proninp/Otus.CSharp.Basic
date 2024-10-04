namespace HomeWork03.Services;
public sealed class ConsoleHelper
{
    public ConsoleHelper()
    {
        Console.CursorVisible = false;
    }

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

        for (int i = belowLineTop; i < Console.WindowHeight; i++)
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

    public void PrintColoredLine(string text, int lineTopPosition, ConsoleColor color)
    {
        var position = Position;
        ClearCurrentLine(lineTopPosition);
        ColoredPrint(text, color);
        Console.CursorTop = position;
    }

    public void PrintConsoleSpecial(string text)
    {
        ColoredPrint(text, ConsoleColor.Magenta);
    }

    public void ColoredPrint(string text, ConsoleColor color)
    {
        var currentColor = Console.ForegroundColor;
        Console.ForegroundColor = color;
        Console.WriteLine(text);
        Console.ForegroundColor = currentColor;
    }

    public void PrintLineWithBackGround(string text, int lineTopPosition, ConsoleColor color)
    {
        var position = Position;
        SetToPosition(lineTopPosition);
        ClearBelow(lineTopPosition);
        Console.BackgroundColor = color;
        Console.WriteLine(text);
        Console.ResetColor();
        SetToPosition(position);
    }
}
