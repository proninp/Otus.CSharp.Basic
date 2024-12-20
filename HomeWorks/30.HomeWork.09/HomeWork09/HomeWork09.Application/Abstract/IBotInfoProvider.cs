namespace HomeWork09.Application.Abstract;
public interface IBotInfoProvider
{
    string Info { get; set; }

    string LastMessageInfo { get; set; }
    string GetBotInfo();

    void Reset();
}
