namespace Gof.Behavioral.Visitor.Serialization;

public class Klass : AstNode
{
    public Klass(string name) : this(name, new Klass("obj", null)) {}

    public Klass(string name, Klass? parent)
    {
        Name = name;
        Parent = parent;
    }

    public string Name { get; }
    public Klass? Parent { get; }

    public override string Stringify(ISerializer serializer) => serializer.Serialize(this);
}
