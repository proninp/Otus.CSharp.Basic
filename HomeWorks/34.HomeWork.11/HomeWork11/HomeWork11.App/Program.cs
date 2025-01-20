using HomeWork11.App;

var arr = new string[] { "Zero", "One", "Two", "Three", "Four", "Five" };
var map = new OtusDictionary();

for (int i = 0; i < arr.Length; i++)
    map.Add(i, arr[i]);

for (int i = 0; i < arr.Length; i++)
    Console.WriteLine($"Key: {i}; Value: {map.Get(i)}");

Console.WriteLine();
map[3] = "Three by Indexer";
Console.WriteLine($"Key: {3}; Value: {map[3]}");