namespace Program02;
public class PlanetsCatalogue
{
    private static int requestsCount;
    private readonly List<Planet> _planets = new();

    public PlanetsCatalogue(params Planet[] planets) : this() =>
        _planets.AddRange(planets);

    public PlanetsCatalogue()
    {
        _planets.Add(new("Венера", 2, 38_025));
        _planets.Add(new("Земля", 3, 40_075, _planets.Last()));
        _planets.Add(new("Марс", 4, 21_344, _planets.Last()));
    }

    public (short orderNumber, int equatorLength, string? error) GetPlanet(string name)
    {
        requestsCount++;
        if (requestsCount % 3 == 0)
            return (default, default, "Вы спрашиваете слишком часто");

        var planet = _planets.FirstOrDefault(x => x.Name == name);
        if (planet is null)
            return (default, default, $"Планеты с названием {name} нет в списке.");
        return (planet.OrderNumber, planet.EquatorLength, default);
    }
}
