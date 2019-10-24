using System;
namespace Gof.Behavioral.ChainOfResponsibility
{
    public class ThrottlingMiddleware : Middleware
    {
        private const int MillisecondsPerMininute = 60_000;
        private readonly int _requestsPerMinute;
        private int _requestCount;
        private long _currentTime;

        public ThrottlingMiddleware(int requestsPerMinute)
        {
            _requestsPerMinute = requestsPerMinute;
            _currentTime = DateTime.Now.Millisecond;
        }

        public override bool Check(string email, string password)
        {
            if (DateTime.Now.Millisecond > _currentTime * MillisecondsPerMininute)
            {
                _requestCount = 0;
                _currentTime = DateTime.Now.Millisecond;
            }
            _requestCount++;
            if (_requestCount > _requestsPerMinute)
                return false;
            return PassNext(email, password);
        }
    }
}
