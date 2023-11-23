namespace Gof.Behavioral.Visitor.Serialization;

public abstract class AstNode
{
    public abstract string Stringify(ISerializer serializer);
}
