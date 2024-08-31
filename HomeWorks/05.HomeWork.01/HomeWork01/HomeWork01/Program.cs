static void WriteTable(int n, string s)
{
    if (n < 1 || n > 6)
    {
        Console.WriteLine("Введите число от 1 до 6");
        return;
    }
    if (string.IsNullOrEmpty(s))
    {
        Console.WriteLine("Текст не может быть пустым");
        return;
    }

}