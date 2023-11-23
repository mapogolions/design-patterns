namespace Gof.Behavioral.ChainOfResponsibility;

public class LazyReviewer(int affectedLines) : Reviewer
{
    private readonly int _affectedLines = affectedLines;

    public override ReviewResult Review(PullRequest pullRequest)
    {
        return pullRequest.AffectedLines > _affectedLines ? ReviewResult.Declined : PassNext(pullRequest);
    }
}
