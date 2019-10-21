namespace Gof.Behavioral.Visitor
{
    public abstract class AstNode
    {
        public abstract T Accept<T>(IVisitor<T> visitor);
    }
}
