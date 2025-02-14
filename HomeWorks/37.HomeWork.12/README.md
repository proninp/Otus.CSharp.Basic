# 37. Observable, Immutable и Concurrent коллекции

### Цель

Тренируемые навыки: работа с

* ObservableCollection
* Immutable коллекциями
* ConcurrentDictionary

**Описание/Пошаговая инструкция выполнения домашнего задания:**

#### Напишите программу "Постоянный покупатель" с двумя классами:

* `Shop` (Магазин)
* `Customer` (Покупатель)

В классе `Shop` должна храниться информация о списке товаров (экземпляры классов `Item`). Также в классе `Shop` должны быть методы `Add` (для добавления товара) и `Remove` (для удаления товара).

В классе `Item` должны быть свойства `Id` (идентификатор товара) и `Name` (название товара).

В классе `Customer` должен быть метод `OnItemChanged`, который будет срабатывать, когда список товаров в магазине обновился. В этом методе надо выводить в консоль информацию о том, какое именно изменение произошло (добавлен товар с таким-то названием и таким-то идентификатором / удален такой-то товар).

В основном файле программы создайте Магазин, создайте Покупателя. Реализуйте через `ObservableCollection` возможность подписки Покупателем на изменения в ассортименте Магазина - все изменения сразу должны отображаться в консоли (должен срабатывать метод `Customer.OnItemChanged`).

* По нажатии клавиши `A` добавляйте новый товар в магазин. Товар должен называться "Товар от <текущее дата и время>", где вместо <текущее дата и время> подставлять текущую дату и время.
* По нажатии клавиши `D` спрашивайте какой товар надо удалить. Пользователь должен ввести идентификатор товара, после чего товар необходимо удалить из ассортимента магазина.
* По нажатии клавиши `X` выходите из программы.

Добавьте в Магазин несколько товаров, удалите какие-то из них - убедитесь, что сообщения выводятся в консоль.

#### Напишите программу "Библиотекарь". Суть:

Пользователю в консоли показывают меню:
* 1 - добавить книгу;
* 2 - вывести список непрочитанного;
* 3 - выйти

Если он вводит `1`, то далее ему пишут "Введите название книги:". Пользователь вводит название - книга запоминается в коллекции.
В качестве коллекции стоит использовать `ConcurrentDictionary<string, int>` (для чего нужен `int` - см.далее).
Если книга с таким названием уже была добавлена ранее - не добавлять и не обновлять ее. Автоматически возвращаемся в меню (снова выводим его в консоль).

Если вводит `2` - на экран выводится список всех ранее введенных книг и в конце - опять меню

Если вводит `3` - выходим из программы.

В выводимом списке книг надо выводить не только их названия, но и вычисленный процент, насколько она прочитана. Например: "Остров сокровищ - 15%".

Для расчета процентов создаем второй поток, который в фоне постоянно перевычисляет проценты.
Между каждой итерацией перевычисления он спит `1` секунду.
Во время итерации перевычисления он берет коллекцию всех книг и по каждой вычисляет новый процент путем прибавления `1%` к предыдущему значению (изначально `0%`). Если дошли до `100%` - удаляем эту книгу из списка.

Таким образом, когда пользователь вызовет вывод списка он может получить что-то вроде:
* Любовь к жизни - `45%`
* Приключения Мюнхгаузена - `17%`
* Незнайка в Солнечном городе - `4%`

#### Напишите программу "Дом, который построил Джек".

В программе должна быть коллекция строк. Каждая строка - строка стихотворения "Дом, который построил Джек".

Изначально коллекция пустая.
Также в программе есть 9 классов - `Part1`, `Part2`, `Part3`, ..., `Part9`
В каждом классе `PartN` есть метод `AddPart`, который на вход принимает коллекцию строк, добавляет в нее новые строки и сохраняет получившуюся коллекцию в свойство `Poem`.

Требуется это делать так, чтобы исходная коллекция не изменилась.
Какие именно строки добавляет каждый класс посмотрите [здесь](https://russkaja-skazka.ru/dom-kotoryiy-postroil-dzhek-stihi-samuil-marshak/) (например `Part3` добавляет третий параграф стихотворения).

Надо создать экземпляры этих классов, а затем последовательно вызвать каждый из методов `AddPart`, передавай в него результат вызова предыдущего метода, примерно так: `MyPart3(MyPart2.Poem)`
В конце работы программы надо вывести значение свойства `Poem` у каждого из классов и убедиться, что изменяя коллекцию в одном классе Вы не затрагивали коллекцию в предыдущем.

**Критерии оценки:**

"Постоянный покупатель": +3 балла
"Библиотекарь": +4 балла
"Дом, который построил Джек": +3 балла.

Минимальный балл: 7

## Решение

[Постоянный покупатель](HomeWork12/HomeWork12.RegularCustomer)

[Библиотекарь](HomeWork12/HomeWork12.Librarian)

[Дом, который построил Джек](HomeWork12/HomeWork12.JacksHouse)