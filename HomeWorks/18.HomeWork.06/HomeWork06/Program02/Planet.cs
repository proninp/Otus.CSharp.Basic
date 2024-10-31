using System.Diagnostics.CodeAnalysis;

namespace Program02;
public class Planet
{
    public string Name { get; init; }

    public short OrderNumber { get; init; }

    public int EquatorLength { get; init; }

    public Planet? PreviousPlanet { get; init; }

    [SetsRequiredMembers]
    public Planet(string name, short number, int equatorLength, Planet? previousPlanet = null)
    {
        Name = name;
        OrderNumber = number;
        EquatorLength = equatorLength;
        PreviousPlanet = previousPlanet;
    }
}
