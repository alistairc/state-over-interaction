namespace StateOverInteraction.Summing.Decoupled;

class Calculator
{
    readonly IMathsService _maths;

    public Calculator(IMathsService maths)
    {
        _maths = maths;
    }

    public int CalculateTotal(int[] numbers)
    {
        var runningTotal = 0;
        foreach (var num in numbers)
            runningTotal = _maths.Add(runningTotal, num);
        return runningTotal;
    }
}