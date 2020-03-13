namespace Gof.Behavioral.Visitor.Canonical
{
    public interface ISerializer
    {
        string Serialize(AstNode node);
        string Serialize(Arrow fn);
        string Serialize(ClassDef cls);
    }
}
