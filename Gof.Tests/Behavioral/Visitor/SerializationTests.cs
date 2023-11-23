using Gof.Behavioral.Visitor.Serialization;

namespace Gof.Tests.Behavioral.Visitor.Serialization;

public class SerializationTests
{
    private readonly ISerializer _serializer = new Serializer();

    [Fact]
    public void ShouldReturnNameOfAstNodeClass()
    {
        // see double dispatch problem
        string someWhereInCode(AstNode node)
        {
            return _serializer.Serialize(node);
        }
        Assert.Equal(nameof(AstNode), someWhereInCode(new Arrow("g", "int", "unit")));
        Assert.Equal(nameof(AstNode), someWhereInCode(new Klass("hero")));
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
        var classHero = new Klass(name: "Hero");
        var classSuperHero = new Klass(name: "SuperHero", parent: classHero);
        Assert.Equal("Hero < obj", classHero.Stringify(_serializer));
        Assert.Equal("SuperHero < Hero < obj", classSuperHero.Stringify(_serializer));
    }
}
