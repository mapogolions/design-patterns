namespace Gof.Behavioral.ChainOfResponsibility;

public class PullRequest(int affectedLines, decimal testCoverage, bool testsPassed)
{
    public int AffectedLines { get; } = affectedLines;

    public decimal TestCoverage { get; } = testCoverage;

    public bool UnitTestsPassed { get; } = testsPassed;
}
