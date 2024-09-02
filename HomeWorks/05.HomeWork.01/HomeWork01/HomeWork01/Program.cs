const int MaxLineWidth = 40;
const int MinInputNumberValue = 1;
const int MaxInputNumberValue = 6;
const string NumberInputMessage = "Введите целое числло:";
const string NumberInputError = "Введите целое число от 1 до 6";
const string TextInputMessage = "Введите строку:";
const string TextInputError = "Текст не может быть пустым";
const string TotalWidthMessage = "Общая ширина не должна превышать {0} символов";
const char Border = '+';

int n = GetNumberFromUser();
if (!IsValidNumberInput(n))
    return;
string text = GetStringFromUser();
WriteTable(n, text);

static int GetNumberFromUser()
{
    Console.WriteLine(NumberInputMessage);
    if (!int.TryParse(Console.ReadLine(), out var number))
        number = 0;
    return number;
}

static string GetStringFromUser()
{
    Console.WriteLine(TextInputMessage);
    return Console.ReadLine() ?? string.Empty;
}

static void WriteTable(int n, string s)
{
    if (!IsValidInput(n, s))
        return;

    var width = GetBandWidth(n, s.Length);
    var borderLine = GetBorderLine(width);
    var firstBand = GetFirstBand(n, s, width);
    var secondBand = GetSecondBand(n, width);
    var thirdBand = GetThirdBand(n, width);

    Console.WriteLine();
    Console.WriteLine(borderLine);
    PrintBand(firstBand);
    Console.WriteLine(borderLine);
    PrintBand(secondBand);
    Console.WriteLine(borderLine);
    PrintBand(thirdBand);
    Console.WriteLine(borderLine);
}

static string[] GetFirstBand(int n, string s, int width)
{
    var band = GetCanvas(n);
    string emptyLine = $"{Border}{new string(' ', width - 2)}{Border}";
    for (int i = 0; i < band.Length; i++)
        band[i] = emptyLine;
    var skipText = new string(' ', n - 1);
    band[^n] = string.Concat($"{Border}{skipText}{s}{skipText}{Border}");
    return band;
}

static string[] GetSecondBand(int n, int width)
{
    var band = GetCanvas(n);
    string evenLine = GetSecondBandLine(width, 0);
    string oddLine = GetSecondBandLine(width, 1);
    for (int i = 0; i < band.Length; i++)
        band[i] = i % 2 == 0 ? evenLine : oddLine;
    return band;
}

static string GetSecondBandLine(int width, int evenOdd)
{
    var line = new char[width];
    line[0] = Border;
    line[^1] = Border;
    for (int i = 1; i < line.Length - 1; i++)
        line[i] = (evenOdd + i) % 2 == 0 ? Border : ' ';
    return new string(line);
}

static string[] GetThirdBand(int n, int width)
{
    var height = width - 2;
    var band = new string[height];
    for (int i = 0; i < height; i++)
        band[i] = GetThirdBandLine(width, i);
    return band;
}

static string GetThirdBandLine(int width, int index)
{
    var line = new string(' ', width).ToCharArray();
    line[0] = Border;
    line[index + 1] = Border;
    line[^(index + 2)] = Border;
    line[^1] = Border;
    return new string(line);
}

static string[] GetCanvas(int n)
{
    var lines = GetCanvasLinesCount(n);
    var canvas = new string[lines];
    return canvas;
}

static string GetBorderLine(int w) =>
    new string(Border, w);

static int GetBandWidth(int n, int len) =>
    (n << 1) + len;

static int GetCanvasLinesCount(int n) =>
    (n << 1) - 1;

static void PrintBand(string[] band) =>
    Array.ForEach(band, Console.WriteLine);

static bool IsValidNumberInput(int n)
{
    if (n is < MinInputNumberValue or > MaxInputNumberValue)
    {
        Console.WriteLine(NumberInputError);
        return false;
    }
    return true;
}

static bool IsValidInput(int n, string s)
{
    switch (true)
    {
        case true when string.IsNullOrEmpty(s):
            Console.WriteLine(TextInputError);
            return false;
        case true when s.Length + n + n > MaxLineWidth:
            Console.WriteLine(string.Format(TotalWidthMessage, MaxLineWidth));
            return false;
    }
    return true;
}