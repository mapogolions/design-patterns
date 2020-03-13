using Gof.Behavioral.Visitor.Canonical;
using Xunit;

namespace Gof.Tests.Behavioral
{
    public class VisitorTests
    {
        private readonly ISerializer _serializer = new Serializer();

        [Fact]
        public void ShouldReturnNameOfAstNodeClass()
        {
            // see double dispatch problem
            string someWhereInCode(AstNode node)
            {
                return _serializer.Visit(node);
            }
            Assert.Equal(nameof(AstNode), someWhereInCode(new Arrow("g", "int", "unit")));
            Assert.Equal(nameof(AstNode), someWhereInCode(new Klass("hero")));
        }

        [Fact]
        public void ShouldReturnStringRepresentationOfFunctionDefinition()
        {
            var node = new Arrow(name: "g", domain: "int", codomain: "unit");
            Assert.Equal("val g : int -> unit = fun", node.Accept(_serializer));
        }

        [Fact]
        public void ShouldReturnStringRepresentationOfClassDefinition()
        {
            var classHero = new Klass(name: "Hero");
            var classSuperHero = new Klass(name: "SuperHero", superClass: classHero);
            Assert.Equal("Hero < obj", classHero.Accept(_serializer));
            Assert.Equal("SuperHero < Hero < obj", classSuperHero.Accept(_serializer));
        }
    }
}
