using System;

namespace Gof.Behavioral.Visitor.EventSourcing.Events
{
    public class GameOn
    {
        public Guid GameId { get; init; }
        public DateTime StartedAt { get; init; }
        public BasketballTeam HomeTeam { get; init; }
        public BasketballTeam AwayTeam { get; init; }
    }
}
