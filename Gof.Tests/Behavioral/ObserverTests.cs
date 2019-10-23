using Gof.Behavioral.Observer;
using Xunit;

namespace Gof.Tests
{
    public class ObserverTests
    {
        private readonly CurrencyPair _usdJpy = new CurrencyPair(name: "USD/JPY", currentRate: 108.41m);
        [Fact]
        public void ShouldNotifyWhenCurrentRateLessThanSupportLevel()
        {
            var sellOrder = new SellOrder(supportLevel: 107.00m);
            _usdJpy.Attach(sellOrder);
            Assert.False(sellOrder.CanSell);
            _usdJpy.CurrentRate = 106.90m;
            Assert.True(sellOrder.CanSell);
        }

        [Fact]
        public void ShouldNotifyWhenCurrentRateGreaterThanResistanceLevel()
        {
            var buyOrder = new BuyOrder(resistanceLevel: 109.50m);
            _usdJpy.Attach(buyOrder);
            Assert.False(buyOrder.CanBuy);
            _usdJpy.CurrentRate = 110.04m;
            Assert.True(buyOrder.CanBuy);
        }
    }
}
