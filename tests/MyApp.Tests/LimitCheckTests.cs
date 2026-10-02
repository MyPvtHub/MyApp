using MyApp.Core;

namespace MyApp.Tests;

public class LimitCheckTests
{
    [Theory]
    [InlineData(50, 100, LimitStatus.Breach)]
    [InlineData(90, 100, LimitStatus.Warning)]
    [InlineData(100, 100, LimitStatus.Warning)]
    [InlineData(101, 100, LimitStatus.Breach)]
    [InlineData(-120, 100, LimitStatus.Breach)]
    public void Evaluate_ReturnsExpectedStatus(decimal exposure, decimal limit, LimitStatus expected)
    {
        Assert.Equal(expected, LimitCheck.Evaluate(exposure, limit));
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-5)]
    public void Evaluate_NonPositiveLimit_Throws(decimal limit)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => LimitCheck.Evaluate(10, limit));
    }
}
