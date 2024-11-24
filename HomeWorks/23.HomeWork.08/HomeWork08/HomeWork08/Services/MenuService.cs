using HomeWork08.Abstractions;
using HomeWork08.Models;

namespace HomeWork08.Services;
public sealed class MenuService
{
    private readonly IPrinter _printer;
    private readonly IInputService _inputService;

    public MenuService(IPrinter printer, IInputService inputService)
    {
        _printer = printer;
        _inputService = inputService;
    }

    public event EventHandler? Restart;
    public event EventHandler? FindEmployee;

    public bool SelectMenu(Dictionary<WorkMode, string> choices)
    {
        var actionText = _inputService.Prompt("[green]Выберите режим работы:[/]", choices.Values);
        var action = choices.First(kvp => kvp.Value == actionText).Key;

        _printer.NewLine();

        switch (action)
        {
            case WorkMode.Restart:
                _printer.Print("[blue]Вы выбрали начать заново.[/]");
                OnRestart();
                OnFindEmployee();
                break;

            case WorkMode.FindEmployee:
                _printer.Print("[yellow]Вы выбрали продолжить поиск.[/]");
                OnFindEmployee();
                break;

            case WorkMode.Exit:
                _printer.Print("[red]Выход из программы.[/]");
                return false;
        }
        _printer.NewLine();
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
