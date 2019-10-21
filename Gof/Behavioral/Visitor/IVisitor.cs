namespace Gof.Behavioral.Visitor
{
    public interface IVisitor<T>
    {
        T Visit(AstNode node);
    }
}
