namespace Gof.Behavioral.Visitor
{
    public abstract class AstNode
    {
        public abstract string Stringify(ISerializer serializer);
    }
}
