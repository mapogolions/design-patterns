namespace Gof.Behavioral.Visitor.Abs
{
    public abstract class AstNode
    {
        public abstract T Accept<T>(IVisitor<T> visitor);
    }
}
