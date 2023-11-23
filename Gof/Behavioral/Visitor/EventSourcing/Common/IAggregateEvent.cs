namespace Gof.Behavioral.Visitor.EventSourcing.Common;

public interface IAggregateEvent<TAggregateEventVisitor>
    where TAggregateEventVisitor : IAggregateEventVisitor
{
    void Accept(TAggregateEventVisitor visitor);
}
