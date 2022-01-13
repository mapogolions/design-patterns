using Gof.Behavioral.Observer.Builtin;
using Xunit;

namespace Gof.Tests.Behavioral.Observer.Builtin
{
    public class ObserverTests
    {
        [Fact]
        public void BuyOrderShouldBeNotifiedAtTheTimeOfAttachment()
        {
            var usdJpy = new CurrencyPair("USD/JPY", 108.41m);
            var sellOrder = new BuyOrder(108m);
            usdJpy.Subscribe(sellOrder);
            Assert.True(sellOrder.CanBuy);
        }

        [Fact]
        public void SellOrderShouldBeNotifiedAtTheTimeOfAttachment()
        {
            var usdJpy = new CurrencyPair("USD/JPY", 108.41m);
            var sellOrder = new SellOrder(109m);
            usdJpy.Subscribe(sellOrder);
            Assert.True(sellOrder.CanSell);
        }

        [Fact]
        public void ShouldNotifyWhenCurrentRateLessThanSupportLevel()
        {
            var usdJpy = new CurrencyPair("USD/JPY", 108.41m);
            var sellOrder = new SellOrder(107.00m);

            usdJpy.Subscribe(sellOrder);
            Assert.False(sellOrder.CanSell);

            usdJpy.CurrentRate = 106.90m;
            Assert.True(sellOrder.CanSell);
        }

        [Fact]
        public void ShouldNotifyWhenCurrentRateGreaterThanResistanceLevel()
        {
            var usdJpy = new CurrencyPair("USD/JPY", 108.41m);
            var buyOrder = new BuyOrder(109.50m);

            usdJpy.Subscribe(buyOrder);
            Assert.False(buyOrder.CanBuy);

            usdJpy.CurrentRate = 110.04m;
            Assert.True(buyOrder.CanBuy);
        }

        [Fact]
        public void ShouldAttachOrderOnlyOnce()
        {
            var usdJpy = new CurrencyPair("USD/JPY", 108.41m);
            var buyOrder = new BuyOrder(114m);

            Assert.Same(usdJpy, usdJpy.Subscribe(buyOrder));
            Assert.NotSame(usdJpy, usdJpy.Subscribe(buyOrder));
        }
    }
}
