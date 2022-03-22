using System.Collections.Generic;

namespace Gof.Behavioral.Visitor.EventSourcing
{
    public interface IAggregateEventVisitor { }

    public interface IAggregate<TAggregateEventVisitor, TEvent>
        where TAggregateEventVisitor : IAggregateEventVisitor
        where TEvent : IAggregateEvent<TAggregateEventVisitor>
    {
        void Aggregate(IEnumerable<TEvent> events);
    }
}
