using System.Collections.Generic;
using System;
using Gof.Structural.Proxy;
using Xunit;

namespace Gof.Tests.Structural
{
    public class ProxyTests
    {
        [Fact]
        public void ShouldProxyEnvVarsConfigProvider()
        {
            var tempEnvVars = new Dictionary<string, string>
            {
                ["Tmp__Loopback"] = "127.0.0.1",
            };
            // create scope to trigger dispose
            {
                using var configProvider = new TempEnvVarsConfigProvider(tempEnvVars, "Tmp__");
                configProvider.Load();

                Assert.True(configProvider.TryGet("loopback", out var loopback));
                Assert.Equal("127.0.0.1", loopback);

                Assert.NotNull(Environment.GetEnvironmentVariable("Tmp__Loopback"));
                Assert.Equal(Environment.GetEnvironmentVariable("Tmp__Loopback"), loopback);
            }

            Assert.Null(Environment.GetEnvironmentVariable("Tmp__Loopback"));
        }

        [Fact]
        public void ShouldGrabAllEnvVarsStartsWithPrefix()
        {
            var configProvider = new EnvVarsConfigProvider(prefix: "Temp");
            Environment.SetEnvironmentVariable("TempFoo", "Bar");
            configProvider.Load();

            Assert.True(configProvider.TryGet("foo", out var value));
            Assert.Equal("Bar", value);

            Environment.SetEnvironmentVariable("TempFoo", null);
        }
    }
}
