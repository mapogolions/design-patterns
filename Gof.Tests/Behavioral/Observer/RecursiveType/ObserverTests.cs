using Gof.Behavioral.Observer.RecursiveType;

namespace Gof.Tests.Behavioral.Observer.RecursiveType;

public class ObserverTests
{
    [Fact]
    public void BuyOrderShouldBeNotifiedAtTheTimeOfAttachment()
    {
        var usdJpy = new CurrencyPair(name: "USD/JPY", currentRate: 108.41m);
        var sellOrder = new BuyOrder(resistanceLevel: 108m);
        usdJpy.Attach(sellOrder);
        Assert.True(sellOrder.CanBuy);
    }

    [Fact]
    public void SellOrderShouldBeNotifiedAtTheTimeOfAttachment()
    {
        var usdJpy = new CurrencyPair(name: "USD/JPY", currentRate: 108.41m);
        var sellOrder = new SellOrder(supportLevel: 109m);
        usdJpy.Attach(sellOrder);
        Assert.True(sellOrder.CanSell);
    }

    [Fact]
    public void ShouldNotifyWhenCurrentRateLessThanSupportLevel()
    {
        var usdJpy = new CurrencyPair(name: "USD/JPY", currentRate: 108.41m);
        var sellOrder = new SellOrder(supportLevel: 107.00m);

        usdJpy.Attach(sellOrder);
        Assert.False(sellOrder.CanSell);

        usdJpy.CurrentRate = 106.90m;
        Assert.True(sellOrder.CanSell);
    }

    [Fact]
    public void ShouldNotifyWhenCurrentRateGreaterThanResistanceLevel()
    {
        var usdJpy = new CurrencyPair(name: "USD/JPY", currentRate: 108.41m);
        var buyOrder = new BuyOrder(resistanceLevel: 109.50m);

        usdJpy.Attach(buyOrder);
        Assert.False(buyOrder.CanBuy);

        usdJpy.CurrentRate = 110.04m;
        Assert.True(buyOrder.CanBuy);
    }

    [Fact]
    public void ShouldAttachOrderOnlyOnce()
    {
        var usdJpy = new CurrencyPair(name: "USD/JPY", currentRate: 108.41m);
        var buyOrder = new BuyOrder(resistanceLevel: 114m);

        Assert.True(usdJpy.Attach(buyOrder));
        Assert.False(usdJpy.Attach(buyOrder));
    }
}
