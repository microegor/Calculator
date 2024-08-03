/// <summary>
/// ������������ ��������� �������� ������������.
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
/// ������ ������������ ��� ���������� �������� �������������� ��������.
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

    /// <summary>
    /// ������� ��������, ������������ �� ������� ������������.
    /// </summary>
    public double Display
    {
        get { return display; }
        set { display = value; }
    }

    /// <summary>
    /// ��������� ����� � �������� �������� �� �������.
    /// </summary>
    /// <param name="value">����� ��� ����������.</param>
    public void AddNumber(int value)
    {
        double num = 0;
        if (!isNewEntry)
        {
            num = Display;
        }
        else
        {
            isNewEntry = false;
        }
        num = num * 10 + value;
        Display = num;
    }

    /// <summary>
    /// �������� �������� ��� ����������.
    /// </summary>
    /// <param name="value">�������� ��� ����������.</param>
    public void SelectAction(Action value)
    {
        result = Display;
        action = value;
        hasLastNumber = false;
        isNewEntry = true;
    }

    /// <summary>
    /// ������� ��� �������� � ���������� �����������.
    /// </summary>
    public void ClearAll()
    {
        Display = 0;
        lastNumber = 0;
        action = Action.None;
    }

    /// <summary>
    /// ��������� ���������� �� ������ ���������� ��������.
    /// </summary>
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
