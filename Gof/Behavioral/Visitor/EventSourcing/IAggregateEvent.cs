namespace Gof.Behavioral.Visitor.EventSourcing
{
    public interface IAggregateEvent<in TAggregateEventVisitor>
        where TAggregateEventVisitor : IAggregateEventVisitor
    {
        void Apply(TAggregateEventVisitor visitor);
    }
}
