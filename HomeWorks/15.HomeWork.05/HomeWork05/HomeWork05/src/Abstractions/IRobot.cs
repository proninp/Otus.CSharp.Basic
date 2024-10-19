namespace HomeWork05.src.Abstractions;
public interface IRobot<T>
{
    string GetInfo();

    List<T> GetComponents();

    string GetRobotType() =>
        "I am a simple robot.";

}
