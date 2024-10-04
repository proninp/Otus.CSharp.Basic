using HomeWork03.Abstractions;
using HomeWork03.Infrastructure;

namespace HomeWork03.Services;
public sealed class AppService
{
    private readonly ConsoleHelper _consoleHelper;
    private readonly OutputManager _outputManager;
    private readonly IEquationPrinter _printer;
    private readonly IExceptionHandler _exceptionHandler;

    public AppService(
        ConsoleHelper consoleHelper,
        OutputManager outputManager,
        IEquationPrinter printer,
        IExceptionHandler exceptionHandler)
    {
        _consoleHelper = consoleHelper;
        _outputManager = outputManager;
        _exceptionHandler = exceptionHandler;
        _printer = printer;
    }

    public void Run()
    {
        _consoleHelper.DisableCursor();
        _consoleHelper.PrintConsoleSpecial(Messages.Instructions.GetIntroductions);

        _outputManager.Create();
        _printer.PrintEquationInput(_outputManager);

        var isWorking = true;
        while (isWorking)
        {
            var key = Console.ReadKey(true);
            isWorking = ProcessKey(key);
        }
    }

    private bool ProcessKey(ConsoleKeyInfo key)
    {
        switch (key.Key)
        {
            case ConsoleKey.DownArrow:
                _outputManager.SelectionIndex++;
                break;
            case ConsoleKey.UpArrow:
                _outputManager.SelectionIndex--;
                break;
            case ConsoleKey.Backspace:
                _outputManager.Del();
                break;
            case ConsoleKey.Enter:
                ProcessEnterKey();
                return true;
            case ConsoleKey.Escape:
                return false;
            default:
                ProcessDefaultKey(key.KeyChar);
                break;
        }
        _printer.PrintEquationInput(_outputManager);
        return true;
    }

    private void ProcessEnterKey()
    {
        try
        {
            var result = _outputManager.Solve();
            _printer.PrintEquationOutput(_outputManager.BottomPosition, result.x1, result.x2);
        }
        catch (Exception ex)
        {
            _exceptionHandler.Handle(ex, _outputManager);
        }
    }

    private void ProcessDefaultKey(char keyChar)
    {
        if (!char.IsControl(keyChar))
            _outputManager.Add(keyChar);
    }
}
