namespace StateOverInteraction.Summing.Concrete;

static class Calculator
{
    public static int CalculateTotal(int[] numbers)
    {
        var runningTotal = 0;
        foreach (var num in numbers)
            runningTotal += num;
        return runningTotal;
    }

    //Review feedback: hey, this would be simpler!
    //public static int CalculateTotal(int[] numbers) => numbers.Sum();
}