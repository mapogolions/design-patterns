namespace Gof.Behavioral.Visitor.Serialization
{
    public class Serializer : ISerializer
    {
        public string Serialize(AstNode node) => nameof(AstNode);
        public string Serialize(Arrow fn) => $"val {fn.Name} : {fn.Domain} -> {fn.Codomain} = fun";
        public string Serialize(Klass cls) =>
            cls.Parent is null ? cls.Name : $"{cls.Name} < {cls.Parent.Stringify(this)}";
    }
}
