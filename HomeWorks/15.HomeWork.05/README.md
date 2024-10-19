# 15. Интерфейсы

### Цель

В этом ДЗ вы научитесь явному вызову интерфейсов, их наследованию и реализации методов по умолчанию.

**Описание/Пошаговая инструкция выполнения домашнего задания:**

1. Создать интерфейс IRobot с публичным методами string GetInfo() и List GetComponents(), а также string GetRobotType() с дефолтной реализацией, возвращающей значение "I am a simple robot.".
2. Создать интерфейс IChargeable с методами void Charge() и string GetInfo().
3. Создать интерфейс IFlyingRobot как наследник IRobot с дефолтной реализацией GetRobotType(), возвращающей строку "I am a flying robot.".
4. Создать класс Quadcopter, реализующий IFlyingRobot и IChargeable. В нём создать список компонентов List _components = new List {"rotor1","rotor2","rotor3","rotor4"} и возвращать его из метода GetComponents().
5. Реализовать метод Charge() должен писать в консоль "Charging..." и через 3 секунды "Charged!". Ожидание в 3 секунды реализовать через Thread.Sleep(3000).
6. Реализовать все методы интерфейсов в классе. До этого пункта достаточно было "throw new NotImplementedException();"


В чат напишите также время, которое вам потребовалось для реализации домашнего задания.

**Критерии оценки:**
* Пункт №1 - 3 балла;
* Пункт №2 - 2 балла;
* Пункт №3 - 2 балла;
* Пункт №4 - 1 балл;
* Пункт №5 - 1 балл;
* Пункт №6 - 1 балл;

Для сдачи достаточно 6 баллов.


### Вывод программы

```
********** Quadcopter **********
Charging...
Charged!
rotor1, rotor2, rotor3, rotor4


********** IChargeable **********
Charging...
Charged!
I am IChargeable from Quadcopter


********** IRobot **********
I am a simple robot.
rotor1, rotor2, rotor3, rotor4
I am IRobot from Quadcopter


********** IFlyingRobot **********
I am a flying robot.
rotor1, rotor2, rotor3, rotor4
I am IRobot from Quadcopter
```