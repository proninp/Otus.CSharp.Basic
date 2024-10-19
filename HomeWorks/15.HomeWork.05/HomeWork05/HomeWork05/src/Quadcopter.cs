using HomeWork05.src.Abstractions;

namespace HomeWork05.src;
public class Quadcopter(IPrinter printer) : IFlyingRobot<string>, IChargeable
{
    private List<string> components = ["rotor1", "rotor2", "rotor3", "rotor4"];

    public void Charge()
    {
        var message = "Charging...";
        var secondsToCharge = 3;

        printer.PrintLine(message);
        Thread.Sleep(TimeSpan.FromSeconds(secondsToCharge));
        printer.PrintLine("Charged!", ConsoleColor.Green);
    }

    public List<string> GetComponents() =>
        components;

    string IChargeable.GetInfo() =>
        $"I am IChargeable from {GetType().Name}";

    string IRobot<string>.GetInfo() =>
        $"I am IRobot from {GetType().Name}";


}
