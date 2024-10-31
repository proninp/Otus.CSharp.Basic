﻿var venus1 = new
{
    Name = "Венера",
    Number = (short)2,
    EquatorLength = 38_025,
    PreviousPlanet = null as object
};

var earth = new
{
    Name = "Земля",
    OrdrNumber = (short)3,
    EquatorLength = 40_075,
    PreviousPlanet = venus1
};

var mars = new
{
    Name = "Марс",
    OrdrNumber = (short)4,
    EquatorLength = 21_344,
    PreviousPlanet = earth
};

var venus2 = new
{
    Name = "Венера",
    OrdrNumber = (short)2,
    EquatorLength = 38_025,
    PreviousPlanet = mars
};

string separator = $"{Environment.NewLine}{new string('-', 100)}{Environment.NewLine}";

Console.WriteLine($"{venus1}");
Console.WriteLine($"Экввалентна Венере = {venus1.Equals(venus1)}");
Console.WriteLine(separator);
Console.WriteLine($"{earth}");
Console.WriteLine($"Экввалентна Венере = {earth.Equals(venus1)}");
Console.WriteLine(separator);
Console.WriteLine($"{mars}");
Console.WriteLine($"Экввалентна Венере = {earth.Equals(venus1)}");
Console.WriteLine(separator);
Console.WriteLine($"{venus2}");
Console.WriteLine($"Экввалентна Венере = {venus2.Equals(venus1)}");