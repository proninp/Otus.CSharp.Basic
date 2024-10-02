using HomeWork03.Infrastructure;

namespace HomeWork03.Services;
public class Application
{
    private readonly ConsoleHelper _consoleHelper;
    private readonly QuadEquationFormatter _formatter;
    private readonly QuadEquationProvider _equationProvider;
    private readonly OutputManager _manager;
    private readonly ExceptionHandler _exceptionHandler;

    public Application(
        ConsoleHelper consoleHelper,
        QuadEquationFormatter formatter,
        QuadEquationProvider equationProvider,
        OutputManager manager,
        ExceptionHandler exceptionHandler)
    {
        _consoleHelper = consoleHelper;
        _formatter = formatter;
        _equationProvider = equationProvider;
        _manager = manager;
        _exceptionHandler = exceptionHandler;
    }

    public void Run()
    {
        _consoleHelper.PrintConsoleSpecial(Messages.Instructions.GetIntroductions);

        var isWorking = true;

        while (isWorking)
        {
            var key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.DownArrow:
                    _manager.SelectionIndex++;
                    break;
                case ConsoleKey.UpArrow:
                    _manager.SelectionIndex--;
                    break;
                case ConsoleKey.Backspace:
                    //menu.BackspaceSelected();
                    break;
                case ConsoleKey.Enter:
                    //isEntePressed = true;
                    break;
                case ConsoleKey.Escape:
                    //menu.Quit();
                    return;
                default:
                    {
                        //if (!char.IsControl(key.KeyChar))
                        //menu.AddSelected(key.KeyChar);
                        break;
                    }
            }
            //if (!isEntePressed)
            //    menu.Show();

        }
    }
}
