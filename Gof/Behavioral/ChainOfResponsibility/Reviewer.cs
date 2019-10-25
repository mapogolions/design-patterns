namespace Gof.Behavioral.ChainOfResponsibility
{
    public abstract class Reviewer
    {
        private Reviewer _next;

        public abstract ReviewResult Review(PullRequest pullRequest);

        protected ReviewResult PassNext(PullRequest pullRequest)
        {
            if (_next is null)
                return ReviewResult.Approved; // pull request is approved by default
            return _next.Review(pullRequest);
        }

        public void With(Reviewer next) => _next = next;
    }
}
