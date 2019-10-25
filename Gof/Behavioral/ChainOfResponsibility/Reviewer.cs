namespace Gof.Behavioral.ChainOfResponsibility
{
    public abstract class Reviewer
    {
        private Reviewer _next;
        public abstract ReviewResult Approve(PullRequest pullRequest);

        protected ReviewResult PassNext(PullRequest pullRequest)
        {
            if (_next is null)
                return ReviewResult.Approved; // pull request is approved by default
            return _next.Approve(pullRequest);
        }

        public void Assignee(Reviewer next) => _next = next;
    }
}
