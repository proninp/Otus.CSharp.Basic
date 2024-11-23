using System.ComponentModel;

namespace HomeWork08.Models;
public enum WorkMode
{
    [Description("Начать заново")]
    Restart,
    [Description("Поиск сотрудника по зарплате")]
    FindEmployee,
    [Description("Выход")]
    Exit
}
