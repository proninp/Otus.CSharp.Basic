using System.ComponentModel;
using System.Reflection;

namespace HomeWork12.Librarian;
public enum Menu
{
    [Description("1 - Добавить книгу")]
    AddABook,
    [Description("2 - Вывести список непрочитанного")]
    ShowUnread,
    [Description("3 - Выйти")]
    Quit
}