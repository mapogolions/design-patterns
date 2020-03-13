namespace Gof.Behavioral.Visitor.Canonical
{
    public interface ISerializer
    {
        string Visit(AstNode node);
        string Visit(Arrow fn);
        string Visit(Klass cls);
    }
}
