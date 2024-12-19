using HomeWork09.Application.Abstract;

namespace HomeWork09.Application.Services;
public class BotInfoProvider : IBotInfoProvider
{
    private string _botInfo = "Информация о боте отсутствует";
    public string BotInfo { get => _botInfo; set => _botInfo = value; }
}
