namespace Gof.Behavioral.Visitor.Canonical
{
    public class Serializer : ISerializer
    {
        public string Visit(AstNode node) => nameof(AstNode);
        public string Visit(Arrow fn) => $"val {fn.Name} : {fn.Domain} -> {fn.Codomain} = fun";
        public string Visit(Klass cls) =>
            cls.SuperClass is null ? cls.Name : $"{cls.Name} < {cls.SuperClass.Accept(this)}";
    }
}
