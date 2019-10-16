using Gof.Behavioral.Visitor.Abs;

namespace Gof.Behavioral.Visitor.Concrete
{
    public class Ref : AstNode
    {
        public Ref(string name) => Name = name;
        public string Name { get; private set; }
        public override T Accept<T>(IVisitor<T> visitor) => visitor.Visit(this);
    }
}
