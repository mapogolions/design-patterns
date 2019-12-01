namespace Gof.Behavioral.ChainOfResponsibility
{
    public class LazyReviewer : Reviewer
    {
        private readonly int _affectedLines;

        public LazyReviewer(int affectedLines) => _affectedLines = affectedLines;

        public override ReviewResult Review(PullRequest pullRequest)
        {
            return pullRequest.AffectedLines > _affectedLines ? ReviewResult.Declined : PassNext(pullRequest);
        }
    }
}
