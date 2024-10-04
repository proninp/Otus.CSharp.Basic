using System.Text;

namespace HomeWork03.Models;
public sealed class Line
{
    private readonly StringBuilder _content;
    private readonly ConsoleColor _defaultColor = ConsoleColor.White;
    private bool _isSelected;

    public Line(string lineText, int position)
    {
        _content = new StringBuilder(lineText);
        Position = position;
    }

    public Line(string lineText, int position, ConsoleColor color) : this(lineText, position)
    {
        Color = color;
    }

    public Line(string prefix, bool isSelected, int position) : this(string.Empty, position)
    {
        Color = _defaultColor;
        Prefix = prefix;
        IsSelected = isSelected;
    }

    public string Prefix { get; init; } = string.Empty;

    public int Position { get; init; }

    public string Text
    {
        get => _content.ToString();
        set
        {
            if (_content.ToString() != value)
            {
                _content.Clear();
                _content.Append(value);
            }
        }
    }

    public ConsoleColor Color { get; set; }

    public bool IsSelected
    {
        get => _isSelected;
        set
        {
            if (_isSelected != value)
            {
                _isSelected = value;
                Color = IsSelected ? ConsoleColor.Green : _defaultColor;
            }
        }
    }

    public void Add(char ch) =>
        _content.Append(ch);

    public void Del()
    {
        if (_content.Length > 0)
            _content.Length--;
    }
}