namespace Gof.Behavioral.Visitor.EventSourcing.Common;

public interface IAggregate<TAggregateEventVisitor, TEvent>
    where TAggregateEventVisitor : IAggregateEventVisitor
    where TEvent : IAggregateEvent<TAggregateEventVisitor>
{
    void Aggregate(IEnumerable<TEvent> events);
}
