using System;
using Gof.Structural.Proxy.ProtectionProxy;
using Xunit;

namespace Gof.Tests.Structural
{
    public class ProtectionProxyTests
    {
        [Fact]
        public void ShouldShowAllFilesWhenPrivilegeIncludesReadOnlyFlag()
        {
            var folder = new FolderProxy(Privilege.ReadOnly | Privilege.WriteOnly);
            Assert.Equal(string.Empty, folder.ShowAll(";"));
        }

        [Fact]
        public void ShouldThrowInvalidOperationExceptionWhenPrivilegeHasWriteOnlyFlag()
        {
            var folder = new FolderProxy(Privilege.WriteOnly);
            Assert.Throws<InvalidOperationException>(() => folder.ShowAll(";"));
        }

        [Fact]
        public void ShouldThrowInvalidOperationExceptionWhenPrivilegeHasReadOnlyFlag()
        {
            var folder = new FolderProxy(Privilege.ReadOnly);
            Assert.Throws<InvalidOperationException>(() => folder.Create("index.js"));
            Assert.Throws<InvalidOperationException>(() => folder.Delete("index.js"));
            Assert.Throws<InvalidOperationException>(() => folder.Rename("index.js", "app.js"));
        }
    }
}
