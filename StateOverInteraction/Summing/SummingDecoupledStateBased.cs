using StateOverInteraction.Summing.Decoupled;

namespace StateOverInteraction.Summing;

class SummingDecoupledStateBased
{
    [Test]
    public void CalculatingTheTotal_ShouldSumTheNumbers()
    {
        var calculator = new Calculator(new MathsService());
        calculator.CalculateTotal(new[] { 1, 2, 3 })
            .ShouldBe(6);
    }
}