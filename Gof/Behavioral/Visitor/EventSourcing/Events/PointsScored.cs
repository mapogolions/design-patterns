namespace Gof.Behavioral.Visitor.EventSourcing.Events;

public record PointsScored : IBasketballGameEvent
{
    public PointsScored(Guid GameId, Guid TeamId, int Points)
    {
        this.GameId = GameId;
        this.TeamId = TeamId;
        this.Points = Points;
    }

    public void Accept(IBasketballGameEventVisitor visitor) => visitor.Visit(this);
    public Guid GameId { get; init; }
    public Guid TeamId { get; init; }
    public int Points { get; init; }

    public void Deconstruct(out Guid GameId, out Guid TeamId, out int Points)
    {
        GameId = this.GameId;
        TeamId = this.TeamId;
        Points = this.Points;
    }
}
