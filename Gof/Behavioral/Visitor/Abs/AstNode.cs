namespace Gof.Behavioral.Visitor.Abs
{
    public abstract class AstNode
    {
        public abstract string Accept(IVisitor visitor);
    }
}
