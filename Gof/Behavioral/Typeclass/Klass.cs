namespace Gof.Behavioral.Typeclass;

public class Klass(string name, Klass? parent) : AstNode
{
    public Klass(string name) : this(name, new Klass("obj", null)) {}

    public string Name { get; } = name;
    public Klass? Parent { get; } = parent;
}
