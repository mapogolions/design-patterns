namespace Gof.Behavioral.Visitor
{
    public class ClassDef : AstNode
    {
        public ClassDef(string name, ClassDef superClass)
        {
            Name = name;
            SuperClass = superClass;
        }

        public ClassDef(string name) : this(name, new ClassDef("obj", null)) {}

        public string Name { get; }
        public ClassDef SuperClass { get; }
        public override T Accept<T>(IVisitor<T> visitor) => visitor.Visit(this);
    }
}
