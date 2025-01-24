namespace HomeWork12.JacksHouse.Parts;
public sealed class Part2 : BasePart
{
    protected override string GetPoemText() =>
        $"А это пшеница,{Environment.NewLine}" +
        $"Которая в темном чулане хранится{Environment.NewLine}" +
        $"В доме,{Environment.NewLine}" +
        $"Который построил Джек.{Environment.NewLine}";
}
