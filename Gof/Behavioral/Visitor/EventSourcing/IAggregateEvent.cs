namespace Gof.Behavioral.Visitor.EventSourcing
{
    public interface IAggregateEvent<in TAggregateEventVisitor>
        where TAggregateEventVisitor : IAggregateEventVisitor
    {
        void Accept(TAggregateEventVisitor visitor);
    }
}
