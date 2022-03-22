using System.Collections.Generic;

namespace Gof.Behavioral.Visitor.EventSourcing
{
    public interface IAggregateBuilder<TAggregate, TEvent, TAggregateEventVisitor>
        where TAggregate : IAggregate<TAggregateEventVisitor, TEvent>
        where TEvent : IAggregateEvent<TAggregateEventVisitor>
        where TAggregateEventVisitor : IAggregateEventVisitor
    {
        TAggregate Build(IEnumerable<TEvent> events);
    }
}
