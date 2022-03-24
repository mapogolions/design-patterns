using System;
using System.Collections.Generic;
using Gof.Behavioral.Visitor.EventSourcing.Common;
using Gof.Behavioral.Visitor.EventSourcing.Events;

namespace Gof.Behavioral.Visitor.EventSourcing
{
    public class BasketballGame : IAggregate<IBasketballGameEventVisitor, IBasketballGameEvent>,
        IBasketballGameEventVisitor
    {
        private int _homeTeamScore = 0;
        private int _awayTeamScore = 0;
        public Guid Id { get; protected set; }
        public BasketballTeam HomeTeam { get; protected set; }
        public BasketballTeam AwayTeam { get; protected set; }
        public DateTime StartedAt { get; protected set; }
        public DateTime EndedAt { get; protected set; }
        public GameStatus Status { get; protected set; } = GameStatus.Pending;
        public (int, int) FinalScore => (_homeTeamScore, _awayTeamScore);

        public void Aggregate(IEnumerable<IBasketballGameEvent> events)
        {
            foreach (var @event in events) @event.Accept((IBasketballGameEventVisitor)this);
        }

        void IBasketballGameEventVisitor.Visit(GameOn @event)
        {
            Id = @event.GameId;
            StartedAt = @event.StartedAt;
            HomeTeam = @event.HomeTeam;
            AwayTeam = @event.AwayTeam;
            Status = GameStatus.Started;
        }

        void IBasketballGameEventVisitor.Visit(PointsScored @event)
        {
            if (Status == GameStatus.Pending)
                throw new InvalidOperationException("Game hasn't started yet");
            if (Status == GameStatus.Over)
                throw new InvalidOperationException("Game over");
            if (Id != @event.GameId)
                throw new ArgumentException(nameof(@event.GameId));
            if (HomeTeam.Id == @event.TeamId)
            {
                _homeTeamScore += @event.Points;
                return;
            }
            if (AwayTeam.Id == @event.TeamId)
            {
                _awayTeamScore += @event.Points;
                return;
            }
            throw new ArgumentException(nameof(@event.TeamId));
        }

        void IBasketballGameEventVisitor.Visit(GameOver @event)
        {
            if (Status == GameStatus.Pending)
                throw new InvalidOperationException("Game hasn't started yet");
            if (Status == GameStatus.Over) return;
            if (Id != @event.GameId)
                throw new ArgumentException(nameof(@event.GameId));
            EndedAt = @event.EndedAt;
            Status = GameStatus.Over;
        }
    }
}
