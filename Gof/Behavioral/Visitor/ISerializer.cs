namespace Gof.Behavioral.Visitor
{
    public interface ISerializer
    {
        string Serialize(AstNode node);
        string Serialize(Arrow fn);
        string Serialize(Klass cls);
    }
}
