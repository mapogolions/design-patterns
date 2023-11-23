namespace Gof.Behavioral.Visitor.Serialization;

public class Arrow(string name, string domain, string codomain) : AstNode
{
    public string Name { get; } = name;
    public string Domain { get; } = domain;
    public string Codomain { get; } = codomain;
    public override string Stringify(ISerializer serializer) => serializer.Serialize(this);
}
