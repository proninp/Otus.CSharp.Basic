using HomeWork03.Abstractions;
using HomeWork03.Models;
using HomeWork03.Models.Enums;

namespace HomeWork03.Services;
public sealed class OutputManager
{
    private readonly ICoefficientable _coefficientProvider;
    private readonly IEquationSolver _solver;
    private readonly IEquationFormatter _formatter;
    private readonly IEquationValidator _equationValidator;
    private readonly CoefficientOrder[] _orders;
    private readonly ConsoleHelper _consoleHelper;
    private int _selectionIndex = 0;
    private Coefficient[] _coefficients = new Coefficient[3];

    public OutputManager(
        ConsoleHelper consoleHelper,
        IEquationSolver solver,
        IEquationFormatter formatter,
        ICoefficientable coefficientProvider,
        IEquationValidator equationValidator)
    {
        _solver = solver;
        _coefficientProvider = coefficientProvider;
        _consoleHelper = consoleHelper;
        _formatter = formatter;
        _equationValidator = equationValidator;
        _orders = [CoefficientOrder.First, CoefficientOrder.Second, CoefficientOrder.Third];
    }

    public int BottomPosition { get; private set; }

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

    public void Create()
    {
        for (int i = 0; i < _coefficients.Length; i++)
            _coefficients[i] = _coefficientProvider.GetCofficient(_orders[i]);

        EquationLine = new Line(_formatter.Format(_coefficients), _consoleHelper.Position, ConsoleColor.Blue);

        for (int i = 0; i < Lines.Length; i++)
            Lines[i] = CreateLine(_coefficients[i].Value, i == 0);

        _consoleHelper.NewLine();
        BottomPosition = _consoleHelper.Position;
    }

    public void Add(char c)
    {
        Lines[SelectionIndex].Add(c);
        UpdateEquationData();
    }

    public void Del()
    {
        Lines[SelectionIndex].Del();
        UpdateEquationData();
    }

    public (double? x1, double? x2) Solve()
    {
        var coefficientValues = _equationValidator.Validate(_coefficients);
        return _solver.Solve(coefficientValues[0], coefficientValues[1], coefficientValues[2]);
    }

    private Line CreateLine(string prefix, bool isSelected)
    {
        _consoleHelper.NewLine();
        var line = new Line(prefix, isSelected, _consoleHelper.Position);
        return line;
    }

    private void UpdateEquationData()
    {
        _coefficients[SelectionIndex] = _coefficientProvider.GetCofficient(_orders[SelectionIndex], Lines[SelectionIndex].Text);
        EquationLine.Text = _formatter.Format(_coefficients);
    }
}
