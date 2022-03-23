using System;

namespace Gof.Behavioral.Visitor.EventSourcing.Events
{
    public record PointsScored(
        Guid GameId,
        Guid TeamId,
        int Points) : IBasketballGameEvent
    {
        public void Accept(IBasketballGameEventVisitor visitor) => visitor.Visit(this);
    }
}
