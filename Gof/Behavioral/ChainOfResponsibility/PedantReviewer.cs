namespace Gof.Behavioral.ChainOfResponsibility
{
    public class PedantReviewer : Reviewer
    {
        private readonly decimal _testCoverage;

        public PedantReviewer(decimal testCoverage) => _testCoverage = testCoverage;

        public override ReviewResult Review(PullRequest pullRequest)
        {
            if (pullRequest.TestCoverage < 90.0m)
                return ReviewResult.RequestedChanges;
            if (pullRequest.UnitTestsPassed is false)
                return ReviewResult.Declined;
            return PassNext(pullRequest);
        }
    }
}
