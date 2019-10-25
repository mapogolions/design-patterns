using Gof.Behavioral.ChainOfResponsibility;
using Xunit;

namespace Gof.Tests.Behavioral
{
    public class ChainOfResponsibilityTests
    {
        [Fact]
        public void ShouldDeclinePullRequestWhenToManyAffectedLines()
        {
            var assignees = new LazyReviewer(affectedLines: 200);
            var actual = assignees.Review(new PullRequest(affectedLines: 1000, testCoverage: 100.0m, testsPassed: true));
            Assert.Equal(ReviewResult.Declined, actual);
        }
    }
}
