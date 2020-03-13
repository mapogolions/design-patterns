namespace Gof.Behavioral.Visitor.Canonical
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
        public override string Stringify(ISerializer serializer) => serializer.Serialize(this);
    }
}
