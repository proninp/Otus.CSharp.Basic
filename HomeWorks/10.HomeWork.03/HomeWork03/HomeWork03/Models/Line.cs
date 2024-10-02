using System.Text;

namespace HomeWork03.Models;
public class Line
{
    private readonly StringBuilder _content;

    public Line(string lineText, int position)
    {
        _content = new StringBuilder(lineText);
        Position = position;
        Color = Console.ForegroundColor;
        IsReprint = true;
    }

    public Line(string prefix, bool isSelected, int position) : this(string.Empty, position)
    {
        Prefix = prefix;
        IsSelected = isSelected;
    }

    public string Prefix { get; init; } = string.Empty;

    public int Position { get; init; }

    public bool IsReprint { get; protected set; }

    public string Text
    {
        get => _content.ToString();
        set
        {
            if (_content.ToString() != value)
            {
                _content.Clear();
                _content.Append(value);
                IsReprint = true;
            }
        }
    }

    public ConsoleColor Color
    {
        get => Color;
        set
        {
            if (Color != value)
            {
                Color = value;
                IsReprint = true;
            }
        }
    }

    public bool IsSelected
    {
        get => IsSelected;
        set
        {
            if (IsSelected != value)
            {
                IsSelected = value;
                Color = IsSelected ? ConsoleColor.Green : Console.ForegroundColor;
                IsReprint = true;
            }
        }
    }

    public void Add(char ch)
    {
        _content.Append(ch);
        IsReprint = true;
    }

    public void Backspace()
    {
        if (_content.Length > 0)
        {
            _content.Length--;
            IsReprint = true;
        }
    }
}
