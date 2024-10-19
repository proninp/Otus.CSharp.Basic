using HomeWork05.src.Abstractions;

namespace HomeWork05.src;
public class Application(IPrintable printer, Quadcopter copter)
{
    public void Run()
    {
        DoQuadcopter(copter);

        DoChargeable(copter);

        DoRobot(copter);

        DoFlyingRobot(copter);
    }

    private void DoQuadcopter(Quadcopter quadcopter)
    {
        printer.PrintTitle("Quadcopter");
        quadcopter.Charge();
        printer.PrintLine(quadcopter.GetComponents());
        printer.PrintLinesSeparation();
    }

    private void DoChargeable(IChargeable chargeableCopter)
    {
        printer.PrintTitle("IChargeable");
        chargeableCopter.Charge();
        printer.PrintLine(chargeableCopter.GetInfo());
        printer.PrintLinesSeparation();
    }

    private void DoRobot(IRobot<string> roboCopter)
    {
        printer.PrintTitle("IRobot");
        printer.PrintLine(roboCopter.GetRobotType());
        printer.PrintLine(roboCopter.GetComponents());
        printer.PrintLine(roboCopter.GetInfo());
        printer.PrintLinesSeparation();
    }

    private void DoFlyingRobot(IFlyingRobot<string> flyingCopter)
    {
        printer.PrintTitle("IFlyingRobot");
        printer.PrintLine(flyingCopter.GetRobotType());
        printer.PrintLine(flyingCopter.GetComponents());
        printer.PrintLine(flyingCopter.GetInfo());
    }
}
