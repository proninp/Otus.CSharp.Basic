﻿namespace HomeWork05.src.Abstractions;
public interface IPrinter
{
    void PrintLine(string line);
    void PrintLine<T>(IEnumerable<T> elements);
    void PrintLine(string line, ConsoleColor color);
    void PrintLinesSeparation();
    void PrintTitle(string title);
}
