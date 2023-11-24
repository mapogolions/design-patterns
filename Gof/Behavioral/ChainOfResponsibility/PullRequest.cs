namespace Gof.Behavioral.ChainOfResponsibility;

public class PullRequest
{
    public PullRequest(int affectedLines, decimal testCoverage, bool testsPassed)
    {
        AffectedLines = affectedLines;
        TestCoverage = testCoverage;
        UnitTestsPassed = testsPassed;
    }

    public int AffectedLines { get; }

    public decimal TestCoverage { get; }

    public bool UnitTestsPassed { get; }
}
