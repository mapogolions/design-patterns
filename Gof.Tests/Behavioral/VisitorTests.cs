using Gof.Behavioral.Visitor.Abs;
using Gof.Behavioral.Visitor.Concrete;
using Xunit;

namespace Gof.Tests.Behavioral
{
    public class VisitorTests
    {
        private readonly IVisitor<string> _serializer = new SerializeVisitor();

        [Fact]
        public void ShouldReturnStringRepresentationOfARefAstNode()
        {
            var node = new Ref("a");
            Assert.Equal("ref -> a", node.Accept(_serializer));
        }

        [Fact]
        public void ShouldReturnStringRepresentationOfAClassDefinition()
        {
            var node = new ClassDef("Hero");
            Assert.Equal("class Hero < obj", node.Accept(_serializer));
        }
    }
}
