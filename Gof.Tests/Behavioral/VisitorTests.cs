using Gof.Behavioral.Visitor.Abs;
using Gof.Behavioral.Visitor.Concrete;
using Xunit;

namespace Gof.Tests.Behavioral
{
    public class VisitorTests
    {
        private readonly IVisitor<string> _serializer = new SerializeVisitor();

        [Fact]
        public void ShouldReturnStringRepresentationOfAFunctionDefinition()
        {
            var node = new Arrow(name: "f", domain: "int", codomain: "unit");
            Assert.Equal("val f : int -> unit = fun", node.Accept(_serializer));
        }

        [Fact]
        public void ShouldReturnStringRepresentationOfAClassDefinition()
        {
            var node = new ClassDef("Hero");
            Assert.Equal("class Hero < obj", node.Accept(_serializer));
        }
    }
}
