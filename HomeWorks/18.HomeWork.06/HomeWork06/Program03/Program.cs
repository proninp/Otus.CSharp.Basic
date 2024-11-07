using Program03;

var planetsCatalogue = new PlanetsCatalogue();

var planetNames = new[] { "Земля", "Лимония", "Марс" };

TooFrequentCrawl(planetsCatalogue, planetNames);

Console.WriteLine();

LimoniaCrawl(planetsCatalogue, planetNames, planetNames[1]);

static void TooFrequentCrawl(PlanetsCatalogue catalogue, IEnumerable<string> planetNames)
{
    int requestsCount = 0;
    var tooFrequentValidator = new Func<string, string?>(p =>
    {
        requestsCount++;
        return requestsCount % 3 == 0 ? "Вы спрашиваете слишком часто" : null;
    });
    
    Console.WriteLine("Вывод стандартного задания:");
    CrawlPlanets(catalogue, planetNames, tooFrequentValidator);
}

static void LimoniaCrawl(PlanetsCatalogue catalogue, IEnumerable<string> planetNames, string limoniaName)
{
    var limoniaValidator = new Func<string, string?>(p => p == limoniaName ? "Это запретная планета" : null);
    Console.WriteLine("(*) Вывод задания со звездочкой:");
    CrawlPlanets(catalogue, planetNames, limoniaValidator);
}

static void CrawlPlanets(PlanetsCatalogue catalogue, IEnumerable<string> planetNames, Func<string, string?> validator)
{
    foreach(var planetName in planetNames)
    {
        var result = catalogue.GetPlanet(planetName, validator);
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
}