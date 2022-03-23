using System;

namespace Gof.Behavioral.Visitor.EventSourcing.Events
{
    public record GameOn(
        Guid GameId,
        DateTime StartedAt,
        BasketballTeam HomeTeam,
        BasketballTeam AwayTeam) : IBasketballGameEvent
    {
        public void Accept(IBasketballGameEventVisitor visitor) => visitor.Visit(this);
    }
}
