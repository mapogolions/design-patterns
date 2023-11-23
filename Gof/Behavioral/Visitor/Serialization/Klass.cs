namespace Gof.Behavioral.Visitor.Serialization;

public class Klass(string name, Klass? parent) : AstNode
{
    public Klass(string name) : this(name, new Klass("obj", null)) {}

    public string Name { get; } = name;
    public Klass? Parent { get; } = parent;

    public override string Stringify(ISerializer serializer) => serializer.Serialize(this);
}
