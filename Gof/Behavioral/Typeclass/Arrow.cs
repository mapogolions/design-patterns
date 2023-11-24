namespace Gof.Behavioral.Typeclass;

public class Arrow : AstNode
{
    public Arrow(string name, string domain, string codomain)
    {
        Name = name;
        Domain = domain;
        Codomain = codomain;
    }

    public string Name { get; }
    public string Domain { get; }
    public string Codomain { get; }
}
