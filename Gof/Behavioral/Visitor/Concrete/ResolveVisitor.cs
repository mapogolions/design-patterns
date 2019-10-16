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
            throw new System.NotImplementedException();
        }
    }
}
