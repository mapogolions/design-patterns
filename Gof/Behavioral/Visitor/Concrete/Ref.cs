using Gof.Behavioral.Visitor.Abs;

namespace Gof.Behavioral.Visitor.Concrete
{
    public class Ref : AstNode
    {
        public Ref(string name) => Name = name;
        public string Name { get; private set; }
        public override string Accept(IVisitor visitor) => visitor.Visit(this);
    }
}
