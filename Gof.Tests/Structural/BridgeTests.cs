using System;
using Gof.Structural.Bridge;
using Xunit;

namespace Gof.Tests.Structural
{
    public class BridgeTests
    {
        [Fact]
        public void ShouldRenderAboutPageWithLightTheme()
        {
            var page = new AboutPage(new LightTheme());
            Assert.Equal("About page has a Light theme", page.Render());
        }

        [Fact]
        public void ShouldRenderContatsPageWithDarkTheme()
        {
            var page = new ContactsPage(new DarkTheme());
            Assert.Equal("Contacts page has a Dark theme", page.Render());
        }
    }
}
