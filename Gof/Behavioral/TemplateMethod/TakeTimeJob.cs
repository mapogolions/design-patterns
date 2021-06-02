using System;
using System.Threading;
using System.Threading.Tasks;

namespace Gof.Behavioral.TemplateMethod
{
    public class TakeTimeJob : BackgroundJob
    {
        private readonly TimeSpan _takeTime;

        public TakeTimeJob(TimeSpan takeTime) => _takeTime = takeTime;

        protected override async Task ExecuteAsync(CancellationToken token = default)
        {
            await Task.Delay(_takeTime, token);
        }
    }
}
