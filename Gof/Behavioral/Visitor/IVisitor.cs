namespace Gof.Behavioral.Visitor
{
    public interface IVisitor<out T>
    {
        T Visit(AstNode node);
    }
}
