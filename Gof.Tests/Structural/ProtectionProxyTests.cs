using System;
using Gof.Structural.Proxy.ProtectionProxy;
using Xunit;

namespace Gof.Tests.Structural
{
    public class ProtectionProxyTests
    {
        [Theory]
        [InlineData(Privilege.WriteOnly)]
        [InlineData(Privilege.ReadOnly | Privilege.WriteOnly)]
        public void ShouldHaveAccessToRenameFileWhenPrivilegeIncludesWriteOnlyFlag(Privilege flag)
        {
            var folder = new FolderProxy(flag);
            Assert.False(folder.Rename("index.js", "app.js"));
            folder.Create("index.js");
            Assert.True(folder.Rename("index.js", "app.js"));
        }

        [Theory]
        [InlineData(Privilege.WriteOnly)]
        [InlineData(Privilege.ReadOnly | Privilege.WriteOnly)]
        public void ShouldHaveAccessToDeleteFileWhenPrivilegeIncludesWriteOnlyFlag(Privilege flag)
        {
            var folder = new FolderProxy(flag);
            Assert.False(folder.Delete("index.js"));
            folder.Create("index.js");
            Assert.True(folder.Delete("index.js"));
        }

        [Theory]
        [InlineData(Privilege.WriteOnly)]
        [InlineData(Privilege.ReadOnly | Privilege.WriteOnly)]
        public void ShouldHaveAccessToCreateNewFileWhenPrivilegeIncludesWriteOnlyFlag(Privilege flag)
        {
            var folder = new FolderProxy(flag);
            Assert.True(folder.Create("index.js"));
        }

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
