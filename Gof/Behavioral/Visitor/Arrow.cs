namespace Gof.Behavioral.Visitor
{
    public class Arrow : AstNode
    {
        public Arrow(string name, string domain, string codomain)
        {
            Name = name;
            Domain = domain;
            Codomain = codomain;
        }
        public string Name { get; private set; }
        public string Domain { get; private set; }
        public string Codomain { get; private set; }
        public override T Accept<T>(IVisitor<T> visitor) => visitor.Visit(this);
    }
}
