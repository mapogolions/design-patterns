using System;
using System.Collections.Generic;
using Gof.Behavioral.Visitor.EventSourcing;
using Gof.Behavioral.Visitor.EventSourcing.Events;
using Xunit;

namespace Gof.Tests.Behavioral.Visitor.EventSourcing
{
    public class EventSourcingTests
    {
        [Fact]
        public void ShouldAggregateBasketballGameEvents()
        {
            var gameId = Guid.NewGuid();
            var startedAt = DateTime.UtcNow;
            var endedAt = startedAt + TimeSpan.FromHours(2);
            var homeTeam = new BasketballTeam(Guid.NewGuid(), "Los Angles Lakers");
            var awayTeam = new BasketballTeam(Guid.NewGuid(), "Maimi Heat");
            var events = new List<IBasketballGameEvent>
            {
                new GameOn(gameId, startedAt, homeTeam, awayTeam),
                new PointsScored(gameId, homeTeam.Id, 3),
                new PointsScored(gameId, awayTeam.Id, 2),
                new PointsScored(gameId, homeTeam.Id, 1),
                new GameOver(gameId, endedAt)
            };

            var game = new BasketballGame();
            game.Aggregate(events);

            Assert.Equal((4, 2), game.FinalScore);
            Assert.Equal(startedAt, game.StartedAt);
            Assert.Equal(endedAt, game.EndedAt);
            Assert.Equal(GameStatus.Over, game.Status);
        }
    }
}
