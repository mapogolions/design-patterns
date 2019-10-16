using System;
using Gof.Behavioral.Visitor.Abs;

namespace Gof.Behavioral.Visitor.Concrete
{
    public class SerializeVisitor : IVisitor
    {
        public string Visit(AstNode node)
        {
            switch (node)
            {
                case Ref rf:
                    return $"ref -> {rf.Name}";
                case ClassDef cls:
                    return $"class {cls.Name} < {cls.SuperClass}";
                default:
                    throw new ArgumentException();
            }
        }
    }
}
