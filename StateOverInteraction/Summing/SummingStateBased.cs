using StateOverInteraction.Summing.Concrete;

namespace StateOverInteraction.Summing;

class SummingStateBased
{
    [Test]
    public void CalculatingTheTotal_ShouldSumTheNumbers()
    {
        Calculator.CalculateTotal(new[] { 1, 2, 3 })
            .ShouldBe(6);
    }
}