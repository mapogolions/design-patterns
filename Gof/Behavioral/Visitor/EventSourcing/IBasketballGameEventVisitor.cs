using Gof.Behavioral.Visitor.EventSourcing.Common;
using Gof.Behavioral.Visitor.EventSourcing.Events;

namespace Gof.Behavioral.Visitor.EventSourcing
{
    public interface IBasketballGameEventVisitor : IAggregateEventVisitor
    {
        void Visit(GameOn @event);
        void Visit(PointsScored @event);
        void Visit(GameOver @event);
    }
}
