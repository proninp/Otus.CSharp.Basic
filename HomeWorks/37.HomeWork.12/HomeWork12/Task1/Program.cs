using Spectre.Console;
using Task1;

var shop = new Shop();
var cutomer1 = new Customer("Магазин 1");
var cutomer2 = new Customer("Магазин 2");


shop.AddObserver(cutomer1);
shop.AddObserver(cutomer2);

SeedShopData(shop);
AnsiConsole.WriteLine();

while (true)
{
    AnsiConsole.MarkupLine("[green]Магазин товаров:[/]");

    foreach (var item in shop)
        AnsiConsole.MarkupLine($"[yellow]ID: {item.Id}[/] - [blue]{item.Name}[/]");

    AnsiConsole.MarkupLine($"{Environment.NewLine}[cyan]Нажмите:[/]");
    AnsiConsole.MarkupLine("[yellow]A[/] - Добавить товар");
    AnsiConsole.MarkupLine("[yellow]D[/] - Удалить товар");
    AnsiConsole.MarkupLine("[yellow]Q[/] - Выход");

    AnsiConsole.WriteLine();

    var input = Console.ReadKey(true).Key;

    switch (input)
    {
        case ConsoleKey.A:
            shop.AddItem();
            break;

        case ConsoleKey.D:
            var id = AnsiConsole.Ask<int>("Введите [yellow]ID товара[/], который хотите удалить:");
            if (!shop.Remove(id))
                AnsiConsole.MarkupLine($"[red]Товар с ID {id} не найден[/].");
            break;

        case ConsoleKey.Q:
            AnsiConsole.MarkupLine("[cyan]Выход из программы...[/]");
            return;

        default:
            AnsiConsole.MarkupLine("[red]Неверный ввод. Попробуйте снова.[/]");
            break;
    }
    AnsiConsole.MarkupLine("\nНажмите любую клавишу для продолжения...");
    Console.ReadKey(true);
    Console.Clear();
}

void SeedShopData(Shop shop)
{
    shop.AddItem();
    shop.AddItem();
    shop.AddItem();
    shop.AddItem();
    shop.Remove(1);
    shop[1] = new Item(shop.GetNewItemId());
}