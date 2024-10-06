# 11. Классы как основа C#

## Реализация класс коллекции - Стэк

### Цель

Цель домашнего задания - научится проектировать классы (обычные и статические), создавать в них методы и свойства

**Описание/Пошаговая инструкция выполнения домашнего задания:**

Стэк - тип данных, представляющий собой коллекцию элементов, организованную по принципу LIFO - Last In - First Out.

Данные в эту коллекцию могут добавляться только "сверху", и извлекать тоже сверху. Если мы добавили элемент1, а потом элемент2, то доступ к Элементу1 мы получим только после того как извлечем Элемент2.

В качестве примера стека может послужить стопка тарелок: мы кладем сверху тарелки, но если мы хотим взять тарелку из середины - надо для начала снять верхние.


**Основное задание**

Нужно создать класс Stack у которого будут следующие свойства:

1. В нем будем хранить строки
2. В качестве хранилища используйте список List
3. Конструктор стека может принимать неограниченное количество входных параметров типа string, которые по порядку добавляются в стек
* Метод Add(string) - добавить элемент в стек
* Метод Pop() - извлекает верхний элемент и удаляет его из стека. При попытке вызова метода Pop у пустого стека - выбрасывать исключение с сообщением "Стек пустой"
* Свойство Size - количество элементов из Стека
* Свойство Top - значение верхнего элемента из стека. Если стек пустой - возвращать null

**Пример работы**

```csharp
var s = new Stack("a", "b", "c");
// size = 3, Top = 'c'
Console.WriteLine($"size = {s.Size}, Top = '{s.Top}'");
var deleted = s.Pop();
// Извлек верхний элемент 'c' Size = 2
Console.WriteLine($"Извлек верхний элемент '{deleted}' Size = {s.Size}");
s.Add("d");
// size = 3, Top = 'd'
Console.WriteLine($"size = {s.Size}, Top = '{s.Top}'");
s.Pop();
s.Pop();
s.Pop();
// size = 0, Top = null
Console.WriteLine($"size = {s.Size}, Top = {(s.Top == null ? "null" : s.Top)}");
s.Pop();
```

**Доп. задание 1**

Создайте класс расширения StackExtensions и добавьте в него метод расширения Merge, который на вход принимает стек s1, и стек s2.
Все элементы из s2 должны добавится в s1 в обратном порядке.
Сам метод должен быть доступен в класс Stack.

```csharp
var s = new Stack("a", "b", "c")
s.Merge(new Stack("1", "2", "3"))
// в стеке s теперь элементы - "a", "b", "c", "3", "2", "1" <- верхний
```

**Доп. задание 2**

В класс Stack и добавьте статический метод Concat, который на вход неограниченное количество параметров типа Stack и возвращает новый стек с элементами каждого стека в порядке параметров, но сами элементы записаны в обратном порядке.

```csharp
var s =Stack.Concat(new Stack("a", "b", "c"), new Stack("1", "2", "3"), new Stack("А", "Б", "В"));
// в стеке s теперь элементы - "c", "b", "a" "3", "2", "1", "В", "Б", "А" <- верхний
```

**Доп. задание 3**

Вместо коллекции - создать класс StackItem, который:
* доступен только для класса Stack (отдельно объект класса StackItem вне Stack создать нельзя);
* хранит текущее значение элемента стека;
* ссылку на предыдущий элемент в стеке;
* Методы, описанные в основном задании переделаны под работу со StackItem;

**Критерии оценки:**

6 баллов - Выполнено основное задание (можно сразу делать с доп. заданием 3 - тогда 8 баллов)

* 1 балла - выполнено доп. задание 1
* 1 балла - выполнено доп. задание 2
* 2 балла - выполнено доп. задание 3

Для зачета достаточно сделать основное задание


## Результаты тестирования

```
[xUnit.net 00:00:00.00] xUnit.net VSTest Adapter v2.4.5+1caef2f33e (64-bit .NET 8.0.1)
[xUnit.net 00:00:00.36]   Discovering: HomeWork04.Tests
[xUnit.net 00:00:00.38]   Discovered:  HomeWork04.Tests
[xUnit.net 00:00:00.39]   Starting:    HomeWork04.Tests
```

* Пройден [HomeWork04.Tests.OutusStackTests.ConcatThreeStacksReturnsCombinedStack](HomeWork04/HomeWork04.Tests/OutusStackTests.cs#L117) [3 ms]
* Пройден [HomeWork04.Tests.OutusStackTests.SizeShouldReturnCorrectNumberOfEmptyStack](HomeWork04/HomeWork04.Tests/OutusStackTests.cs#L76) [1 ms]
* Пройден [HomeWork04.Tests.OutusStackTests.PopShouldReturnTopItemAndDecreaseSize](HomeWork04/HomeWork04.Tests/OutusStackTests.cs#L35) [< 1 ms]
* Пройден [HomeWork04.Tests.OutusStackTests.PopAllElementsReturnsNullForTopWhenStackIsEmpty](HomeWork04/HomeWork04.Tests/OutusStackTests.cs#L61) [< 1 ms]
* Пройден [HomeWork04.Tests.OutusStackTests.PopShouldThrowExceptionWhenStackIsEmpty](HomeWork04/HomeWork04.Tests/OutusStackTests.cs#L50) [< 1 ms]
* Пройден [HomeWork04.Tests.OutusStackTests.ConcatShouldCombineStacks](HomeWork04/HomeWork04.Tests/OutusStackTests.cs#L102) [< 1 ms]
* Пройден [HomeWork04.Tests.OutusStackTests.ConstructorShouldInitializeStackWithGivenItems](HomeWork04/HomeWork04.Tests/OutusStackTests.cs#L6) [< 1 ms]
* Пройден [HomeWork04.Tests.OutusStackTests.MergeShouldRetainOrderWhenMergingStacks](HomeWork04/HomeWork04.Tests/OutusStackTests.cs#L142) [< 1 ms]
* Пройден [HomeWork04.Tests.OutusStackTests.SizeShouldReturnCorrectNumberOfItems](HomeWork04/HomeWork04.Tests/OutusStackTests.cs#L88) [< 1 ms]
* Пройден [HomeWork04.Tests.OutusStackTests.AddShouldIncreaseSizeAndSetTop](HomeWork04/HomeWork04.Tests/OutusStackTests.cs#L20) [< 1 ms]

```
Тестовый запуск выполнен.
Всего тестов: 10
     Пройдено: 10
 Общее время: 1,0349 Секунды
```