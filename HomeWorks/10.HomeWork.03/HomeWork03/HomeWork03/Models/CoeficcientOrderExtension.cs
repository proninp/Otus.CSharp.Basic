using System.ComponentModel;
using System.Reflection;

namespace HomeWork03.Models;
public static class CoeficcientOrderExtension
{
    public static string GetDescription(this Enum value)
    {
        FieldInfo? field = value.GetType()?.GetField(value.ToString());
        DescriptionAttribute? attribute = (DescriptionAttribute?)field?.GetCustomAttribute(typeof(DescriptionAttribute));
        return attribute is null ? value.ToString() : attribute.Description;
    }
}
