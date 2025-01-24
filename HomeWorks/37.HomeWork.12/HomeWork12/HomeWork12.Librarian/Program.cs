using System.Collections.Concurrent;
using HomeWork12.Librarian;
using Spectre.Console;

var library = new ConcurrentDictionary<string, int>();

var task = Task.Run(CalculatePercents);

ShowMenu();

void ShowMenu()
{
    while (true)
    {
        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<Menu>()
                .Title("Выберите действие:")
                .AddChoices(Enum.GetValues<Menu>())
                .UseConverter(option => option.GetDescription()));


        switch (choice)
        {
            case Menu.AddABook:
                AddNewBook();
                break;

            case Menu.ShowUnread:
                ShowLibrary();
                break;

            case Menu.Quit:
                AnsiConsole.MarkupLine("[green]До свидания![/]");
                return;

            default:
                AnsiConsole.MarkupLine("[red]Неверный выбор![/]");
                break;
        }
        Continue();
    }
}

void AddNewBook()
{
    var title = AnsiConsole.Ask<string>("[yellow]Введите название книги:[/]");
    if (library.TryAdd(title, 0))
        AnsiConsole.MarkupLine($"[green]Книга \"{title}\" добавлена![/]");
}

void ShowLibrary()
{
    foreach (var kvp in library)
        AnsiConsole.MarkupLine($"[cyan]\"{kvp.Key}\"[/] - {kvp.Value}%");
}

void Continue()
{
    AnsiConsole.MarkupLine($"{Environment.NewLine}Нажмите любую клавишу для продолжения...");
    Console.ReadKey(true);
    Console.Clear();
}

async Task CalculatePercents()
{
    while (true)
    {
        Parallel.ForEach(library, (kvp) =>
        {
            if (kvp.Value < 100)
                library[kvp.Key]++;
            else
                library.TryRemove(kvp);
        });
        await Task.Delay(TimeSpan.FromSeconds(1));
    }
}