namespace Gof.Behavioral.ChainOfResponsibility;

public class PedantReviewer(decimal testCoverage) : Reviewer
{
    private readonly decimal _testCoverage = testCoverage;

    public override ReviewResult Review(PullRequest pullRequest)
    {
        if (pullRequest.TestCoverage < _testCoverage)
            return ReviewResult.RequestedChanges;
        return pullRequest.UnitTestsPassed ? PassNext(pullRequest) : ReviewResult.Declined;
    }
}
