namespace Gof.Behavioral.Typeclass;

public class Arrow(string name, string domain, string codomain) : AstNode
{
    public string Name { get; } = name;
    public string Domain { get; } = domain;
    public string Codomain { get; } = codomain;
}
