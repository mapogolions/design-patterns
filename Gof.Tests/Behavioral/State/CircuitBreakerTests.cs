using Gof.Behavioral.State.CircuitBreaker;
using Gof.Behavioral.State.Promise;

namespace Gof.Tests.Behavioral.State;

public class CircuitBreakerTests
{
    private readonly Exception _error1 = new Exception();
    private readonly Exception _error2 = new Exception();

    [Fact]
    public void ShouldCloseCircuitWhenItIsHalfOpenAndNextCallSucceeded()
    {
        // Arrange
        var clock = new FakeClock();
        var breakDuration = TimeSpan.FromSeconds(2);
        var circuitBreaker = new CircuitBreaker<int>(1, breakDuration, clock);
        circuitBreaker.Fail(-1, _error1);
        clock.Advance(breakDuration);
        _ = circuitBreaker.IsOpen; // half open state

        // Act + Assert
        Assert.False(circuitBreaker.IsOpen);
        circuitBreaker.Success();
        Assert.False(circuitBreaker.IsOpen);
    }

    [Fact]
    public void ShouldOpenCircuitWhenItIsHalfOpenAndNextCallFailed()
    {
        // Arrange
        var clock = new FakeClock();
        var breakDuration = TimeSpan.FromSeconds(2);
        var circuitBreaker = new CircuitBreaker<int>(1, breakDuration, clock);
        circuitBreaker.Fail(-1, _error1);
        clock.Advance(breakDuration);
        _ = circuitBreaker.IsOpen; // half open state

        // Act + Assert
        Assert.False(circuitBreaker.IsOpen);
        circuitBreaker.Fail(-2, _error2);
        Assert.True(circuitBreaker.IsOpen);
    }

    [Fact]
    public void CircuitShouldStayOpenUntilSpecifiedPointOfTime()
    {
        var clock = new FakeClock();
        var circuitBreaker = new CircuitBreaker<int>(2, TimeSpan.FromSeconds(2), clock);
        circuitBreaker.Fail(-1, _error1);
        circuitBreaker.Fail(-2, _error2);

        Assert.True(circuitBreaker.IsOpen);
        clock.Advance(TimeSpan.FromSeconds(1));
        Assert.True(circuitBreaker.IsOpen);
    }

    [Theory]
    [InlineData(2)]
    [InlineData(3)]
    public void ShouldHalfOpenCircuitAfterSpecifiedBreakPeriod(int seconds)
    {
        var clock = new FakeClock();
        var circuitBreaker = new CircuitBreaker<int>(2, TimeSpan.FromSeconds(2), clock);
        circuitBreaker.Fail(-1, _error1);
        circuitBreaker.Fail(-2, _error2);

        Assert.True(circuitBreaker.IsOpen);
        clock.Advance(TimeSpan.FromSeconds(seconds));
        Assert.False(circuitBreaker.IsOpen);
    }

    [Fact]
    public void ShouldCloseCircuitWhenThresholdReached()
    {
        var circuitBreaker = new CircuitBreaker<int>(2, TimeSpan.FromMinutes(1), new FakeClock());
        circuitBreaker.Fail(-1, _error1);
        circuitBreaker.Fail(-2, _error2);
        Assert.True(circuitBreaker.IsOpen);
    }

    [Fact]
    public void ShouldNotCloseCircuitWhenThreholdIsNotReached()
    {
        var circuitBreaker = new CircuitBreaker<int>(2, TimeSpan.FromMinutes(1), new FakeClock());
        circuitBreaker.Fail(-1, _error1);
        Assert.False(circuitBreaker.IsOpen);
    }

    [Fact]
    public void CircuitShouldNotBeOpenByDefault()
    {
        var circuitBreaker = new CircuitBreaker<int>(1, TimeSpan.FromSeconds(1), new FakeClock());
        Assert.False(circuitBreaker.IsOpen);
    }
}

public class FakeClock : ISystemClock
{
    private DateTime _now;

    public FakeClock(DateTime now)
    {
        _now = now;
    }

    public FakeClock() : this(new DateTime(2000, 1, 1, 0, 0, 0, 0, 0)) { }
    public DateTime UtcNow => _now;

    public DateTime Advance(TimeSpan delta)
    {
        var prev = _now;
        _now += delta;
        return prev;
    }
}
