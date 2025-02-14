﻿using Program02;

var planetsCatalogue = new PlanetsCatalogue();

var planetNames = new[] { "Земля", "Лимония", "Марс" };

foreach (var planetName in planetNames)
{
    var result = planetsCatalogue.GetPlanet(planetName);
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