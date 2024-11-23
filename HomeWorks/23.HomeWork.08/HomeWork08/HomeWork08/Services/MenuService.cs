using HomeWork08.Abstractions;
using HomeWork08.Models;

namespace HomeWork08.Services;
public sealed class MenuService(IPrinter printer)
{
    public event EventHandler? Restart;
    public event EventHandler? FindEmployee;

    public bool SelectMenu(Dictionary<WorkMode, string> choices)
    {
        var actionText = printer.Prompt("[green]Выберите режим работы:[/]", choices.Values);

        var action = choices.First(kvp => kvp.Value == actionText).Key;

        printer.NewLine();

        switch (action)
        {
            case WorkMode.Restart:
                printer.Print("[blue]Вы выбрали начать заново.[/]");
                OnRestart();
                OnFindEmployee();
                break;

            case WorkMode.FindEmployee:
                printer.Print("[yellow]Вы выбрали продолжить поиск.[/]");
                OnFindEmployee();
                break;

            case WorkMode.Exit:
                printer.Print("[red]Выход из программы.[/]");
                return false;
        }
        printer.NewLine();
        return true;
    }

    private void OnRestart()
    {
        Restart?.Invoke(this, EventArgs.Empty);
    }

    private void OnFindEmployee()
    {
        FindEmployee?.Invoke(this, EventArgs.Empty);
    }
}
