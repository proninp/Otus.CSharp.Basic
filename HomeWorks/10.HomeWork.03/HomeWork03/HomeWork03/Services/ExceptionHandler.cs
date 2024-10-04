using HomeWork03.Abstractions;
using HomeWork03.Exceptions;
using HomeWork03.Infrastructure;
using HomeWork03.Models;
using HomeWork03.Models.Enums;
using System.Text;

namespace HomeWork03.Services;
public sealed class ExceptionHandler : IExceptionHandler
{
    private readonly ConsoleHelper _consoleHelper;

    public ExceptionHandler(ConsoleHelper consoleHelper)
    {
        _consoleHelper = consoleHelper;
    }

    public void Handle(Exception ex, OutputManager outputManager)
    {
        var errorMessage = GetFormatedData(ex);
        var color = GetConsoleColor(ex);
        _consoleHelper.PrintLineWithBackGround(errorMessage, outputManager.BottomPosition, color);
    }

    public void CollectExceptionData<T>(Exception ex, params T[] coefficients)
    {
        var data = ex.Data;
        data.Add(CoefficientOrder.First.GetDescription(), coefficients[0]);
        data.Add(CoefficientOrder.Second.GetDescription(), coefficients[1]);
        data.Add(CoefficientOrder.Third.GetDescription(), coefficients[2]);
    }

    public Exception CreateValidationException(Coefficient coefficient)
    {
        var errorSb = new StringBuilder()
            .Append(string.Format(Messages.Exceptions.IncorrectParameterText, coefficient.Order.GetDescription()));

        if (coefficient.IsBigNumber)
        {
            errorSb.AppendLine()
                   .Append(string.Format(Messages.Exceptions.AvailableInputRangeText, int.MinValue, int.MaxValue));
            return new OutOfValidRangeException(errorSb.ToString());
        }
        if (coefficient.IsEmpty)
        {
            errorSb.AppendLine()
                .Append(Messages.Exceptions.ParameterNotSpecifiedText);
        }
        return new InvalidCastException(errorSb.ToString());
    }

    private string GetFormatedData(Exception ex)
    {
        var message = ex.Message;
        var separator = new string('-', 60);

        var sb = new StringBuilder(Environment.NewLine)
            .AppendLine(separator)
            .AppendLine(message)
            .AppendLine(separator);

        foreach(var key in ex.Data.Keys)
            sb.AppendLine($"{key.ToString()}: {ex.Data[key]?.ToString() ?? string.Empty}");

        var result = sb.ToString().TrimEnd(Environment.NewLine.ToCharArray());
        return result;
    }

    private ConsoleColor GetConsoleColor(Exception ex)
    {
        var severity = GetSeverity(ex);
        return severity switch
        {
            Severity.Warning => ConsoleColor.DarkYellow,
            Severity.Exception or Severity.Error => ConsoleColor.DarkRed,
            Severity.Fatal => ConsoleColor.DarkMagenta,
            _ => ConsoleColor.White
        };
    }

    private Severity GetSeverity(Exception ex)
    {
        return ex switch
        {
            OutOfValidRangeException => Severity.Warning,
            InvalidCastException or ArgumentException => Severity.Exception,
            NoRealValuesException => Severity.Error,
            _ => Severity.Fatal,
        };
    }
}
