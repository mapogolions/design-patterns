using System;
using Gof.Behavioral.Visitor.Abs;

namespace Gof.Behavioral.Visitor.Concrete
{
    public class SerializeVisitor : IVisitor<string>
    {
        public string Visit(AstNode node)
        {
            switch (node)
            {
                case Arrow fn:
                    return $"val {fn.Name} : {fn.Domain} -> {fn.Codomain} = fun";
                case ClassDef cls when cls.SuperClass is null:
                    return cls.Name;
                case ClassDef cls:
                    return $"{cls.Name} < {cls.SuperClass.Accept(this)}";
                default:
                    throw new ArgumentException();
            }
        }
    }
}
