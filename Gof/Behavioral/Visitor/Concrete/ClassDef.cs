using Gof.Behavioral.Visitor.Abs;

namespace Gof.Behavioral.Visitor.Concrete
{
    public class ClassDef : AstNode
    {
        public ClassDef(string name, string superClass = "obj")
        {
            Name = name;
            SuperClass = superClass;
        }
        public string Name { get; private set; }
        public string SuperClass { get; private set; }
        public override string Accept(IVisitor visitor) => visitor.Visit(this);
    }
}
