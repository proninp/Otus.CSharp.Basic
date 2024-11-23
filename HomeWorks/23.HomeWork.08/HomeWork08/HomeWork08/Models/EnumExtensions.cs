using System.ComponentModel;
using System.Reflection;

namespace HomeWork08.Models;
public static class EnumExtensions
{
    public static string GetDescription<T>(this T value) where T : Enum
    {
        var fieldInfo = typeof(T).GetField(value.ToString());
        var descriptionAttribute = fieldInfo?.GetCustomAttribute<DescriptionAttribute>();
        return descriptionAttribute?.Description ?? value.ToString();
    }
}
