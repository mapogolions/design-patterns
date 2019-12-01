namespace Gof.Behavioral.ChainOfResponsibility
{
    public abstract class Reviewer
    {
        private Reviewer _next;

        public abstract ReviewResult Review(PullRequest pullRequest);

        protected ReviewResult PassNext(PullRequest pullRequest)
        {
            return _next?.Review(pullRequest) ?? ReviewResult.Approved;
        }

        public void With(Reviewer next) => _next = next;
    }
}
