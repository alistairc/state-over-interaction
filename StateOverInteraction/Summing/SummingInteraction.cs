using Moq;
using StateOverInteraction.Summing.Decoupled;

namespace StateOverInteraction.Summing;

public class SummingInteraction
{
    [Test]
    public void CalculatingTheTotal_ShouldSumTheNumbers()
    {
        var mockMaths = new Mock<IMathsService>();
        mockMaths.Setup(a => a.Add(It.IsAny<int>(), It.IsAny<int>())).Returns(123);

        var calc = new Calculator(mockMaths.Object);

        var result = calc.CalculateTotal(new[] { 1, 2, 3 });

        mockMaths.Verify(a => a.Add(0, 1), Times.Once);
        mockMaths.Verify(a => a.Add(123, 2), Times.Once);
        mockMaths.Verify(a => a.Add(123, 3), Times.Once);

        result.ShouldBe(123);
    }

    [Test]
    public void Addition_ShouldAdd()
    {
        var maths = new MathsService();
        maths.Add(2, 3).ShouldBe(5);
    }
}