namespace Gof.Behavioral.Visitor.Abs
{
    public interface IVisitor<T>
    {
        T Visit(AstNode node);
    }
}
