# 30. Делегаты, Event-ы, добавляем асинхронное выполнение

Создание Telegram-бота

### Цель

Научиться работать с Telegram Bot API, реализовать обработку сообщений, использовать делегаты и события для управления процессом обработки, асинхронно работать с внешними API

**Описание/Пошаговая инструкция выполнения домашнего задания:**

Вам предстоит написать консольное приложение на C#, которое реализует простого Telegram-бота.

1. Создайте Telegram-бота через [BotFather](https://core.telegram.org/bots/features#botfather)
2. Создайте консольное приложение и реализуйте подключение к боту через токен. Используйте библиотеку [Telegram.Bot](https://github.com/TelegramBots/Telegram.Bot)
3. Реализуйте обработчик входящих сообщений через IUpdateHandler. Создайте класс UpdateHandler, который реализует интерфейс IUpdateHandler из библиотеки Telegram.Bot.
При получении сообщения типа UpdateType.Message бот должен ответить "Сообщение успешно принято".

Пример кода:

```csharp
var botClient = new TelegramBotClient("<token>");
var receiverOptions = new ReceiverOptions
{
    AllowedUpdates = [UpdateType.Message],
    DropPendingUpdates = true
};
var handler = new UpdateHandler();
botClient.StartReceiving(handler, receiverOptions);

var me = await botClient.GetMe();
Console.WriteLine($"{me.FirstName} запущен!");

await Task.Delay(-1); // Устанавливаем бесконечную задержку, чтобы наш бот работал постоянно
```

4. Добавьте делегаты и события: в классе UpdateHandler в начале и в конце обработки сообщений выкидывайте события (event) OnHandleUpdateStarted и OnHandleUpdateCompleted соответственно.
События должны быть типа MessageHandler.
В основном коде программы подпишитесь на эти события, а в обработчиках их срабатываний выводите соответствующие уведомления в консоль: `Началась обработка сообщения '{message}'`
и `Закончилась обработка сообщения '{message}'`.
При завершении работы приложения незабудьте отписаться от событий. Для этого можно использовать `try/finally`

5. Реализуйте отмену асинхронных операции при нажатии клавиши `A`.
В конце работы программы выводите теперь текст `Нажмите клавишу A для выхода` и ожидайте нажатия любой клавиши.
Если нажата клавиша `A` - выходите из программы и отмените все асинхронные операции. В противном случае выводите информацию о Telegram-боте. Информацию нужно взять из метода `botClient.GetMe()`
Реализовать отмену асинхронной операции нужно с использованием `CancellationTokenSource`.

6. Добавьте команду /cat в телеграмм бот, которая будет возвращать случайный факт о кошках. Факт можно взять из [API](https://catfact.ninja/#/Facts/getRandomFact)
Пример кода:

```csharp
record CatFactDto(string Fact, int length);

var cts = new CancellationTokenSource();
using var client = new HttpClient();
var catFact = await client.GetFromJsonAsync<CatFactDto>("https://catfact.ninja/fact", cts.Token);
```

Советы:
Избегайте утечку токена вашего Telegram-бота. При отправки ДЗ на проверку убедитесь, что в коде нет токена. Также не делает коммиты в git-репозиторий с токеном.
Полезные ресурсы:
* Документация библиотеки: https://github.com/TelegramBots/Telegram.Bot
* Пример реализации: https://github.com/TelegramBots/Telegram.Bot.Examples

**Критерии оценки:**

* Пункты 1-5: +8 балла
* Пункт 6: +2 балла

Для сдачи достаточно 8 баллов.


## Решение

Решение выполнено с использование Web Api.
Реализованы два Api метода:
* `GET`: `/api/TelegramBot/info` - получение нформации о состоянии бота
* `POST`: `/api/TelegramBot/stop` - остановка работы бота через передачу токена отмены

![api](docs/images/01.png)


Информация о боте после старта приложения:

![info1](/images/02.png)


Информация о боте после отправки сообшения:

![info2](/docs/images/03.png)


Выполнение команды остановки бота:

![stop](/docs/images/04.png)


Информация о боте после выполнения запроса остановки:

![info3](/docs/images/05.png)


Пример выполнения команды `\cat`:

![catFact](/docs/images/06.png)