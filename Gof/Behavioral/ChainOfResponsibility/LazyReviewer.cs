namespace Gof.Behavioral.ChainOfResponsibility
{
    public class LazyReviewer : Reviewer
    {
        private readonly int _affectedLines;
        public LazyReviewer(int affectedLinesLimit) => _affectedLines = affectedLinesLimit;

        public override ReviewResult Approve(PullRequest pullRequest)
        {
            if (pullRequest.AffectedLines > _affectedLines)
                return ReviewResult.Declined;
            return PassNext(pullRequest);
        }
    }
}
