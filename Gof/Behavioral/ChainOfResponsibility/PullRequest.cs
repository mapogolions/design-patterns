namespace Gof.Behavioral.ChainOfResponsibility
{
    public class PullRequest
    {
        private readonly int _affectedLines;
        private readonly decimal _testCoverage;
        private readonly bool _testsPassed;

        public PullRequest(int affectedLines, decimal testCoverage, bool testsPassed)
        {
            _affectedLines = affectedLines;
            _testCoverage = testCoverage;
            _testsPassed = testsPassed;
        }

        public int AffectedLines => _affectedLines;
        public decimal TestCoverage => _testCoverage;
        public bool UnitTestsPassed => _testsPassed;
    }
}
