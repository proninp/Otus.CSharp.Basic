using Program02;

var planetsCatalogue = new PlanetsCatalogue();
var planetNames = new[] { "Земля", "Лимония", "Марс" };

foreach (var planetsName in planetNames)
{
    var result = planetsCatalogue.GetPlanet(planetsName);
    if (string.IsNullOrEmpty(result.error))
    {
        Console.WriteLine($"Название: {planetsName}; " +
            $"Порядковый номер: {result.orderNumber}; " +
            $"Длина экватора: {result.equatorLength}");
    }
    else
    {
        Console.WriteLine(result.error);
    }
}