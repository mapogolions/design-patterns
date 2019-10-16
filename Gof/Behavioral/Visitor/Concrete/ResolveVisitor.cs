using System;
using System.Collections.Generic;
using Gof.Behavioral.Visitor.Abs;

namespace Gof.Behavioral.Visitor.Concrete
{
    public class ResolveVisitor : IVisitor<bool>
    {
        private readonly Dictionary<string, AstNode> _scope = new Dictionary<string, AstNode>();
        public ResolveVisitor(Dictionary<string, AstNode> scope) => _scope = scope;
        public ResolveVisitor() {}
        public bool Visit(AstNode node)
        {
            switch (node)
            {
                case Arrow fn:
                    return _scope.ContainsKey(fn.Name);
                case ClassDef cls:
                    return _scope.ContainsKey(cls.Name);
                default:
                    throw new ArgumentException();
            }
        }
    }
}
