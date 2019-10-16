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
            var node = new Arrow(name: "g", domain: "int", codomain: "unit");
            Assert.Equal("val g : int -> unit = fun", node.Accept(_serializer));
        }

        [Fact]
        public void ShouldReturnStringRepresentationOfAClassDefinition()
        {
            var classHero = new ClassDef(name: "Hero");
            var classSuperHero = new ClassDef(name: "SuperHero", superClass: classHero);
            Assert.Equal("Hero < obj", classHero.Accept(_serializer));
            Assert.Equal("SuperHero < Hero < obj", classSuperHero.Accept(_serializer));
        }
    }
}
