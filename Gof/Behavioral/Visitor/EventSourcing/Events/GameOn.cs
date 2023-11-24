namespace Gof.Behavioral.Visitor.EventSourcing.Events;

public record GameOn : IBasketballGameEvent
{
    public GameOn(Guid GameId,
        DateTime StartedAt,
        BasketballTeam HomeTeam,
        BasketballTeam AwayTeam)
    {
        this.GameId = GameId;
        this.StartedAt = StartedAt;
        this.HomeTeam = HomeTeam;
        this.AwayTeam = AwayTeam;
    }

    public void Accept(IBasketballGameEventVisitor visitor) => visitor.Visit(this);
    public Guid GameId { get; init; }
    public DateTime StartedAt { get; init; }
    public BasketballTeam HomeTeam { get; init; }
    public BasketballTeam AwayTeam { get; init; }

    public void Deconstruct(out Guid GameId, out DateTime StartedAt, out BasketballTeam HomeTeam, out BasketballTeam AwayTeam)
    {
        GameId = this.GameId;
        StartedAt = this.StartedAt;
        HomeTeam = this.HomeTeam;
        AwayTeam = this.AwayTeam;
    }
}
