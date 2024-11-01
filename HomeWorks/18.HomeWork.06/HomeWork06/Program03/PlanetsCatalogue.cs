namespace Program03;
public class PlanetsCatalogue
{
    private readonly List<Planet> _planets = new();

    public PlanetsCatalogue(params Planet[] planets) : this() =>
        _planets.AddRange(planets);

    public PlanetsCatalogue()
    {
        _planets.Add(new("Венера", 2, 38_025));
        _planets.Add(new("Земля", 3, 40_075, _planets.Last()));
        _planets.Add(new("Марс", 4, 21_344, _planets.Last()));
    }

    public (short orderNumber, int equatorLength, string? error) GetPlanet(string name, Func<string, string?> planetValidator)
    {
        string? error = planetValidator(name);
        if (!string.IsNullOrEmpty(error))
            return (default, default, error);

        var planet = _planets.FirstOrDefault(x => x.Name == name);
        
        if (planet is null)
            return (default, default, $"Планеты с названием {name} нет в списке.");

        return (planet.OrderNumber, planet.EquatorLength, default);
    }
}
