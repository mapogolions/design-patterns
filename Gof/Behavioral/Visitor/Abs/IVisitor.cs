namespace Gof.Behavioral.Visitor.Abs
{
    public interface IVisitor
    {
        string Visit(AstNode node);
    }
}
