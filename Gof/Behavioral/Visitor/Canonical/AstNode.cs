namespace Gof.Behavioral.Visitor.Canonical
{
    public abstract class AstNode
    {
        public abstract string Stringify(ISerializer serializer);
    }
}
