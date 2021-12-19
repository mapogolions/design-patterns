using System;
using Gof.Structural.Flyweight.JBogardMediatr;
using Xunit;

namespace Gof.Tests.Structural
{
    public class FlyweightTests
    {
        [Theory]
        [InlineData(110, 95.0, true, ReviewResult.Approved)]
        [InlineData(110, 95.0, false, ReviewResult.Declined)]
        [InlineData(110, 89.0, true, ReviewResult.RequestChanges)]
        [InlineData(400, 95, true, ReviewResult.RequestChanges)]
        [InlineData(400, 95, false, ReviewResult.Declined)]
        public void ShouldReviePullRequest(int affectedLines, decimal testCoverage, bool unitTestsPassed,
            ReviewResult expected)
        {
            var request = new PullRequest(affectedLines, testCoverage, unitTestsPassed);
            var services = MockServices<PullRequest, ReviewResult>(new ReviewPullRequest(affectedLines: 200, testCoverage: 90));
            var mediatr = new Mediatr(services);

            Assert.Equal(expected, mediatr.Send(request));
            Assert.Equal(expected, mediatr.SendOptimized(request));
        }

        private static ServiceProvider MockServices<TReq, TRes>(IEndpoint<TReq, TRes> handler) where TReq : IRequest<TRes>
            => type => type.IsAssignableFrom(handler.GetType()) ? handler : throw new InvalidOperationException();
    }

    public record PullRequest(int AffectedLines, decimal TestCoverage, bool UnitTestsPassed) : IRequest<ReviewResult>;

    public enum ReviewResult
    {
        Approved,
        RequestChanges,
        Declined
    }

    public class ReviewPullRequest : IEndpoint<PullRequest, ReviewResult>
    {
        private readonly int _affectedLines;
        private readonly decimal _testCoverage;

        public ReviewPullRequest(int affectedLines, decimal testCoverage)
        {
            _affectedLines = affectedLines;
            _testCoverage = testCoverage;
        }

        public ReviewResult Act(PullRequest request)
        {
            if (!request.UnitTestsPassed) return ReviewResult.Declined;
            if (request.AffectedLines > _affectedLines || request.TestCoverage < _testCoverage)
            {
                return ReviewResult.RequestChanges;
            }
            return ReviewResult.Approved;
        }
    }
}
