using System.Text;
using HomeWork09.Application.Abstract;

namespace HomeWork09.Application.Services;
public class BotInfoProvider : IBotInfoProvider
{
    private const string NoInformationText = "Информация о боте отсутствует";

    public string Info { get; set; } = NoInformationText;

    public string LastMessageInfo { get; set; } = string.Empty;

    public string GetBotInfo()
    {
        var sb = new StringBuilder(Info);
        if (!string.IsNullOrEmpty(LastMessageInfo))
            sb.AppendLine().Append(LastMessageInfo);
        return sb.ToString();
    }

    public void Reset()
    {
        Info = NoInformationText;
        LastMessageInfo = string.Empty;
    }
}
