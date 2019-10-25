namespace Gof.Behavioral.ChainOfResponsibility
{
    public class PullRequest
    {
        public int AffectedLines { get; set; }
        public decimal TestCoverage { get; set; }
        public bool UnitTestsPassed { get; set; }
    }
}
