using Gof.Behavioral.ChainOfResponsibility;
using Xunit;

namespace Gof.Tests.Behavioral
{
    public class ChainOfResponsibilityTests
    {
        [Theory]
        [InlineData(200, ReviewResult.Declined)]
        [InlineData(1000, ReviewResult.Approved)]
        public void ShouldDeclinePullRequestWhenToManyAffectedLinesOfCode(int affectedLines, ReviewResult expected)
        {
            var pullRequest = new PullRequest(affectedLines: 1000, testCoverage: 100.0m, testsPassed: true);
            var assignees = new LazyReviewer(affectedLines);
            Assert.Equal(expected, assignees.Review(pullRequest));
        }

        [Fact]
        public void ShouldDeclinePullRequestWhenTestsAreFailed()
        {
            var pullRequest = new PullRequest(affectedLines: 10, testCoverage: 100.0m, testsPassed: false);
            var assignees = new PedantReviewer(testCoverage: 90.0m);
            Assert.Equal(ReviewResult.Declined, assignees.Review(pullRequest));
        }

        [Theory]
        [InlineData(50.0, ReviewResult.RequestedChanges)]
        [InlineData(95.0, ReviewResult.Approved)]
        public void ShouldApproveOrRequireChangesDependingOnTestCoverage(decimal testCoverage, ReviewResult expected)
        {
            var pullRequest = new PullRequest(testCoverage: testCoverage, affectedLines: 10, testsPassed: true);
            var assignees = new PedantReviewer(testCoverage: 90.0m);
            Assert.Equal(expected, assignees.Review(pullRequest));
        }

        [Fact]
        public void PullRequestShouldBeDeclinedByLazyReviewer()
        {
            var pullRequest = new PullRequest(affectedLines: 1000, testCoverage: 100.0m, testsPassed: true);
            var assignees = new PedantReviewer(testCoverage: 90.0m);
            assignees.With(new LazyReviewer(affectedLines: 100));
            Assert.Equal(ReviewResult.Declined, assignees.Review(pullRequest));
        }
    }
}
