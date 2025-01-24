using System.Collections.Immutable;
using HomeWork12.JacksHouse.Parts;
using Spectre.Console;

ImmutableList<string> poem = [];

var part1 = new Part1();
var part2 = new Part2();
var part3 = new Part3();
var part4 = new Part4();
var part5 = new Part5();
var part6 = new Part6();
var part7 = new Part7();
var part8 = new Part8();
var part9 = new Part9();

var fullPoemList =
    part9.AddPoem(
        part8.AddPoem(
            part7.AddPoem(
                part6.AddPoem(
                    part5.AddPoem(
                        part4.AddPoem(
                            part3.AddPoem(
                                part2.AddPoem(
                                    part1.AddPoem(poem
                                    )))))))));


AnsiConsole.MarkupLine("[green]******** Paert 1: ********:[/]");
PrintList(part1.Poem);

AnsiConsole.MarkupLine("[green]******** Paert 2: ********:[/]");
PrintList(part2.Poem);

AnsiConsole.MarkupLine("[green]******** Paert 3: ********:[/]");
PrintList(part3.Poem);

AnsiConsole.MarkupLine("[green]******** Paert 4: ********:[/]");
PrintList(part4.Poem);

AnsiConsole.MarkupLine("[green]******** Paert 5: ********:[/]");
PrintList(part5.Poem);

AnsiConsole.MarkupLine("[green]******** Paert 6: ********:[/]");
PrintList(part6.Poem);

AnsiConsole.MarkupLine("[green]******** Paert 7: ********:[/]");
PrintList(part7.Poem);

AnsiConsole.MarkupLine("[green]******** Paert 8: ********:[/]");
PrintList(part8.Poem);

AnsiConsole.MarkupLine("[green]******** Paert 9: ********:[/]");
PrintList(part9.Poem);

void PrintList(IEnumerable<string> list)
{
    foreach (var item in list)
        AnsiConsole.WriteLine(item);
}


