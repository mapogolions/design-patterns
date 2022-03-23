using System;

namespace Gof.Behavioral.Visitor.EventSourcing.Events
{
    public class PointsScored
    {
        public Guid GameId { get; init; }
        public Guid TeamId { get; init; }
        public int Points { get; init; }
    }
}
