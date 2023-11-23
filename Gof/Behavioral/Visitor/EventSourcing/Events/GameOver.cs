namespace Gof.Behavioral.Visitor.EventSourcing.Events;

public record GameOver(Guid GameId, DateTime EndedAt) : IBasketballGameEvent
{
    public void Accept(IBasketballGameEventVisitor visitor) => visitor.Visit(this);
}
