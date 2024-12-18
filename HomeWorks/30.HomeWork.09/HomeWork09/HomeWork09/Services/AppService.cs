using HomeWork09.Abstract;
using Spectre.Console;

namespace HomeWork09.Services;
public class AppService
{
    private readonly ICancellationTokenProvider _tokenProvider;
    private readonly IBotInfoProvider _botInfoProvider;

    public AppService(ICancellationTokenProvider tokenProvider, IBotInfoProvider botInfoProvider)
    {
        _tokenProvider = tokenProvider;
        _botInfoProvider = botInfoProvider;
    }

    public async Task Run(CancellationToken stoppingToken)
    {
        string? input;
        do
        {
            Console.WriteLine("Введите значение (или 'A' для выхода):");
            input = Console.ReadLine();
            if (string.Equals(input, "A", StringComparison.OrdinalIgnoreCase))
                break;
            AnsiConsole.MarkupLine($"[bold]{_botInfoProvider.BotInfo}[/]");
        } while (true);
        _tokenProvider.Cancel();
    }
}
