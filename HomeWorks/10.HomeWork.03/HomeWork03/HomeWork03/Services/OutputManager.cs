using HomeWork03.Models;
using System.Text;

namespace HomeWork03.Services;
public class OutputManager
{
    private QuadEquationProvider _equationProvider;
    private QuadEquationFormatter _formatter;
    private ConsoleHelper _consoleHelper;
    private int _selectionIndex = 0;

    public OutputManager(QuadEquationProvider equationProvider, QuadEquationFormatter formatter, ConsoleHelper consoleHelper)
    {
        _equationProvider = equationProvider;
        _consoleHelper = consoleHelper;
        _formatter = formatter;
        Equation = _equationProvider.GetNewEquation();
        Create();
    }

    public QuadEquation Equation { get; set; }

    public Line EquationLine { get; set; }

    public Line[] Lines { get; init; } = new Line[3];

    public int SelectionIndex
    {
        get => _selectionIndex;
        set
        {
            Lines[_selectionIndex].IsSelected = false;
            if (value < 0)
                _selectionIndex = Lines.Length - 1;
            else if (value >= Lines.Length)
                _selectionIndex = 0;
            else
                _selectionIndex = value;
            Lines[_selectionIndex].IsSelected = true;
        }
    }

    private void Create()
    {
        _consoleHelper.NewLine();
        EquationLine = new Line(_formatter.Format(Equation), _consoleHelper.Position);

        var i = 0;
        Lines[i++] = CreateLine(Equation.A.Order.GetDescription(), true);
        Lines[i++] = CreateLine(Equation.B.Order.GetDescription(), false);
        Lines[i++] = CreateLine(Equation.C.Order.GetDescription(), false);
        _consoleHelper.SetToPosition(EquationLine.Position);
    }

    private Line CreateLine(string prefix, bool isSelected)
    {
        _consoleHelper.NewLine();
        return new Line(prefix, isSelected, _consoleHelper.Position);
    }

    public string GetFullOutputAsText()
    {
        if (Equation is null)
            return string.Empty;
        
        var output = new StringBuilder();
        output.Append(EquationLine.Text).Append(Environment.NewLine);
        foreach (var line in Lines)
            output.Append(line).Append(Environment.NewLine);

        return output.ToString().TrimEnd(Environment.NewLine.ToCharArray());
    }
}
