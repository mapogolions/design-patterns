using Gof.Behavioral.Visitor.EventSourcing.Common;

namespace Gof.Behavioral.Visitor.EventSourcing.Events;

public interface IBasketballGameEventVisitor : IAggregateEventVisitor
{
    void Visit(GameOn @event);
    void Visit(PointsScored @event);
    void Visit(GameOver @event);
}
