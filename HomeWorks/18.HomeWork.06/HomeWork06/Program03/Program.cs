using Program03;

var planetsCatalogue = new PlanetsCatalogue();

var planetNames = new[] { "Земля", "Лимония", "Марс" };

for (int i = 0; i < planetNames.Length; i++)
{
    var planetName = planetNames[i];
    
    var result = planetsCatalogue.GetPlanet(planetName, planetName =>
        (planetName == planetNames[1]) ? "Это запретная планета" : null);

    if (string.IsNullOrEmpty(result.error))
    {
        Console.WriteLine($"Название: {planetName}; " +
            $"Порядковый номер: {result.orderNumber}; " +
            $"Длина экватора: {result.equatorLength}");
    }
    else
    {
        Console.WriteLine(result.error);
    }
}