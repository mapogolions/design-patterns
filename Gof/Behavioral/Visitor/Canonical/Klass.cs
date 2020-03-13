namespace Gof.Behavioral.Visitor.Canonical
{
    public class Klass : AstNode
    {
        public Klass(string name, Klass superClass)
        {
            Name = name;
            SuperClass = superClass;
        }

        public Klass(string name) : this(name, new Klass("obj", null)) {}

        public string Name { get; }
        public Klass SuperClass { get; }
        public override string Accept(ISerializer serializer) => serializer.Visit(this);
    }
}
