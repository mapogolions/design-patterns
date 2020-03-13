using Gof.Behavioral.Visitor.Canonical;
using Xunit;

namespace Gof.Tests.Behavioral
{
    public class VisitorTests
    {
        private readonly ISerializer _serializer = new SerializeVisitor();

        [Fact]
        public void ShouldReturnNameOfAstNodeClass()
        {
            // see double dispatch problem
            string someWhereInCode(AstNode node)
            {
                return _serializer.Serialize(node);
            }
            Assert.Equal(nameof(AstNode), someWhereInCode(new Arrow("g", "int", "unit")));
            Assert.Equal(nameof(AstNode), someWhereInCode(new ClassDef("hero")));
        }

        [Fact]
        public void ShouldReturnStringRepresentationOfFunctionDefinition()
        {
            var node = new Arrow(name: "g", domain: "int", codomain: "unit");
            Assert.Equal("val g : int -> unit = fun", node.Stringify(_serializer));
        }

        [Fact]
        public void ShouldReturnStringRepresentationOfClassDefinition()
        {
            var classHero = new ClassDef(name: "Hero");
            var classSuperHero = new ClassDef(name: "SuperHero", superClass: classHero);
            Assert.Equal("Hero < obj", classHero.Stringify(_serializer));
            Assert.Equal("SuperHero < Hero < obj", classSuperHero.Stringify(_serializer));
        }
    }
}
