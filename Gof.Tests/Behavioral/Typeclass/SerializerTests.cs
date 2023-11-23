using Gof.Behavioral.Typeclass;

namespace Gof.Tests.Behavioral.Typeclass;

public class SerializationTests
{
    // double dispatch problem stay unsolved
    // [Fact]
    // public void ShouldReturnNameOfAstNodeClass()
    // {
    //     // see double dispatch problem
    //     string someWhereInCode(AstNode node)
    //     {
    //         return node.Stringify();
    //     }
    //     Assert.Equal(nameof(AstNode), someWhereInCode(new Arrow("g", "int", "unit")));
    //     Assert.Equal(nameof(AstNode), someWhereInCode(new Klass("hero")));
    // }

    [Fact]
    public void ShouldReturnStringRepresentationOfFunctionDefinition()
    {
        var node = new Arrow(name: "g", domain: "int", codomain: "unit");
        Assert.Equal("val g : int -> unit = fun", node.Stringify());
    }

    [Fact]
    public void ShouldReturnStringRepresentationOfClassDefinition()
    {
        var classHero = new Klass(name: "Hero");
        var classSuperHero = new Klass(name: "SuperHero", parent: classHero);
        Assert.Equal("Hero < obj", Serializer.Serialize(classHero, SerializerInstances.KlassSerializer));
        Assert.Equal("SuperHero < Hero < obj", classSuperHero.Stringify());
    }
}
