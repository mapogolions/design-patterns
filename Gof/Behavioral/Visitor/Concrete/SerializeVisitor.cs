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
                    return $"val f : {fn.Domain} -> {fn.Codomain} = fun";
                case ClassDef cls:
                    return $"class {cls.Name} < {cls.SuperClass}";
                default:
                    throw new ArgumentException();
            }
        }
    }
}
