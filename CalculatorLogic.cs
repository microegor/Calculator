/// <summary>
/// Перечисление возможных действий калькулятора.
/// </summary>
public enum Action
{
    None,
    Multiple,
    Share,
    Plus,
    Minus
}

/// <summary>
/// Логика калькулятора для выполнения основных арифметических операций.
/// </summary>
public class CalculatorLogic
{
    private double display;
    private double result;
    private double prevNumber = 0;
    private double lastNumber = 0;
    private bool hasLastNumber = false;
    private Action action = Action.None;
    private bool isNewEntry = false;
    private bool hasDecimalSeparator = false;

    public double Display
    {
        get { return display; }
        set { display = value; }
    }

    public void AddDecimalSeparator()
    {
        if (!hasDecimalSeparator)
        {
            hasDecimalSeparator = true;
            Display = double.Parse(Display.ToString() + ",");
        }
    }

    public void AddNumber(int value)
    {
        if (isNewEntry)
        {
            Display = 0;
            isNewEntry = false;
        }

        string displayStr = Display.ToString();
        if (hasDecimalSeparator && !displayStr.Contains(","))
        {
            displayStr += ",";
        }   
        displayStr += value.ToString();

        Display = double.Parse(displayStr);
    }

    public void SelectAction(Action value)
    {
        result = Display;
        action = value;
        hasLastNumber = false;
        isNewEntry = true;
        hasDecimalSeparator = false;
    }

    public void ClearAll()
    {
        Display = 0;
        lastNumber = 0;
        action = Action.None;
        hasDecimalSeparator = false;
    }

    public void Calculate()
    {
        if (!hasLastNumber)
        {
            lastNumber = Display;
            hasLastNumber = true;
        }
        switch (action)
        {
            case Action.None:
                break;
            case Action.Multiple:
                result = result * lastNumber;
                Display = result;
                break;
            case Action.Share:
                result = result / lastNumber;
                Display = result;
                break;
            case Action.Plus:
                result = result + lastNumber;
                Display = result;
                break;
            case Action.Minus:
                result = result - lastNumber;
                Display = result;
                break;
        }
    }
}
