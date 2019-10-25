namespace Gof.Behavioral.ChainOfResponsibility
{
    public class LazyReviewer : Reviewer
    {
        private readonly int _affectedLines;
        public LazyReviewer(int affectedLines) => _affectedLines = affectedLines;

        public override ReviewResult Review(PullRequest pullRequest)
        {
            if (pullRequest.AffectedLines > _affectedLines)
                return ReviewResult.Declined;
            return PassNext(pullRequest);
        }
    }
}
