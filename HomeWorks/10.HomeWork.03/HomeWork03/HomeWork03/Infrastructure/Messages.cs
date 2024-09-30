namespace HomeWork03.Infrastructure;
public static class Messages
{
    public static class Inputs
    {
        public const string Separator = " ";
        public const string ASign = "a";
        public const string BSign = "b";
        public const string CSign = "c";
        public const string SelectedText = "> ";
    }

    public static class Exceptions
    {
        public const string IncorrectFirstArgument = "Параметр 'a' не может быть равен нулю в квадратном уравнении";
        public const string IncorrectParameterText = "Неверный формат параметра {0}:";
        public const string AvailableInputRangeText = "Допустимый диапазон значений от {0} до {1}";
        public const string NoRealValuesText = "Вещественных значений не найдено";
    }

    public static class Instructions
    {
        public static string GetIntroductions => "# Для перемещения по меню используйте стрелки вверх и вниз;" +
            $"{Environment.NewLine}Знак \"-\" меняет знак коэффициента;" +
            $"{Environment.NewLine}Для удаления используйте Backspace;" +
            $"{Environment.NewLine}Для расчета уравнения введите все три коэффициента и нажмите Enter;" +
            $"{Environment.NewLine}Для выхода нажмите Esc{Environment.NewLine}";
    }
}