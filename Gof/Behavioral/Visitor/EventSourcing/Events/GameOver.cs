using System;

namespace Gof.Behavioral.Visitor.EventSourcing.Events
{
    public class GameOver
    {
        public Guid GameId { get; init; }
        public DateTime EndedAt { get; init; }
    }
}
