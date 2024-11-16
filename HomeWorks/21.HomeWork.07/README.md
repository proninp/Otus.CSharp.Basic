# 21. Взаимосвязь циклов и рекурсии

### Цель

В этом задании вы сами попробуете создать алгоритм использующий рекурсию и его аналог с использованием цикла.
Опционально вы можете проверить скорость работы этих двух алгоритмов.

**Описание/Пошаговая инструкция выполнения домашнего задания:**

1. Реализовать метод нахождения $n$-го члена последовательности Фибоначчи по формуле $F(n) = F(n-1) + F(n-2)$ с помощью рекурсивных вызовов.
2. Реализовать метод нахождения $n$-го члена последовательности Фибоначчи по формуле $F(n) = F(n-1) + F(n-2)$ с помощью цикла.
3. Добавить подсчёт времени на выполнение рекурсивного и итеративного методов с помощью `Stopwatch` и написать сколько времени для значений `5`, `10` и `20`.

**Критерии оценки:**

* Пункт 1 - 4 балла
* Пункт 2 - 4 балла
* Пункт 3 - 2 балла

Минимальное количество баллов для сдачи: 8 баллов.


## Решение

Реализовано при помощи библиотеки [BenchmarkDotNet](https://github.com/dotnet/BenchmarkDotNet)

Вывод программы:

| Method                    | N  | Mean          | Allocated |
|-------------------------- |--- |--------------:|----------:|
| IterativeBenchmark        | 5  |      9.333 ns |      40 B |
| RecoursiveBenchmark       | 5  |     14.392 ns |         - |
| RecoursiveCachedBenchmark | 5  |     10.347 ns |         - |
| IterativeBenchmark        | 10 |     14.981 ns |      40 B |
| RecoursiveBenchmark       | 10 |    176.263 ns |         - |
| RecoursiveCachedBenchmark | 10 |     10.272 ns |         - |
| IterativeBenchmark        | 20 |     28.928 ns |      40 B |
| RecoursiveBenchmark       | 20 | 21,638.302 ns |         - |
| RecoursiveCachedBenchmark | 20 |      9.893 ns |         - |


**Legends**

*  N         : Value of the 'N' parameter
*  Mean      : Arithmetic mean of all measurements
*  Allocated : Allocated memory per single operation (managed only, inclusive, 1KB = 1024B)
*  1 ns      : 1 Nanosecond (0.000000001 sec)