namespace HomeWork05.src.Abstractions;
public interface IFlyingRobot<T> : IRobot<T>
{
    new string GetRobotType() =>
        "I am a flying robot.";
}
