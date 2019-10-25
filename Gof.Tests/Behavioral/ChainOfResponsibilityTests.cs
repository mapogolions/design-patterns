using Gof.Behavioral.ChainOfResponsibility;
using Xunit;

namespace Gof.Tests.Behavioral
{
    public class ChainOfResponsibilityTests
    {
        [Fact]
        public void ShouldDeclinePullRequestWhenToManyAffectedLines()
        {
            var review = new LazyReviewer(affectedLines: 200);
            var actual = review.Approve(new PullRequest(affectedLines: 1000, testCoverage: 100.0m, testsPassed: true));
            Assert.Equal(ReviewResult.Declined, actual);
        }
    }
}
