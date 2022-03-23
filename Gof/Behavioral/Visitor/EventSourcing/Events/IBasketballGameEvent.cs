using Gof.Behavioral.Visitor.EventSourcing.Common;

namespace Gof.Behavioral.Visitor.EventSourcing.Events
{
    public interface IBasketballGameEvent : IAggregateEvent<IBasketballGameEventVisitor> { }
}
