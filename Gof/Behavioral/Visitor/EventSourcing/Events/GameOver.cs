namespace Gof.Behavioral.Visitor.EventSourcing.Events;

public record GameOver : IBasketballGameEvent
{
    public GameOver(Guid GameId, DateTime EndedAt)
    {
        this.GameId = GameId;
        this.EndedAt = EndedAt;
    }

    public void Accept(IBasketballGameEventVisitor visitor) => visitor.Visit(this);
    public Guid GameId { get; init; }
    public DateTime EndedAt { get; init; }

    public void Deconstruct(out Guid GameId, out DateTime EndedAt)
    {
        GameId = this.GameId;
        EndedAt = this.EndedAt;
    }
}
