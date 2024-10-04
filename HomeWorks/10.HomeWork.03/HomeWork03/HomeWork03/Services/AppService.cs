using HomeWork03.Abstractions;
using HomeWork03.Infrastructure;

namespace HomeWork03.Services;
public sealed class AppService
{
    private readonly ConsoleHelper _consoleHelper;
    private readonly OutputManager _manager;
    private readonly IEquationPrinter _printer;
    private readonly IExceptionHandler _exceptionHandler;

    public AppService(
        ConsoleHelper consoleHelper,
        OutputManager manager,
        IEquationPrinter printer,
        IExceptionHandler exceptionHandler)
    {
        _consoleHelper = consoleHelper;
        _manager = manager;
        _exceptionHandler = exceptionHandler;
        _printer = printer;
    }

    public void Run()
    {
        _consoleHelper.PrintConsoleSpecial(Messages.Instructions.GetIntroductions);

        _manager.Create();
        _printer.PrintEquationInput(_manager);

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
                _manager.SelectionIndex++;
                break;
            case ConsoleKey.UpArrow:
                _manager.SelectionIndex--;
                break;
            case ConsoleKey.Backspace:
                _manager.Del();
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
        _printer.PrintEquationInput(_manager);
        return true;
    }

    private void ProcessEnterKey()
    {
        try
        {
            var result = _manager.Solve();
            _printer.PrintEquationOutput(_manager.BottomPosition, result.x1, result.x2);
        }
        catch (Exception ex)
        {
            _exceptionHandler.Handle(ex, _manager);
        }
    }

    private void ProcessDefaultKey(char keyChar)
    {
        if (!char.IsControl(keyChar))
            _manager.Add(keyChar);
    }
}
