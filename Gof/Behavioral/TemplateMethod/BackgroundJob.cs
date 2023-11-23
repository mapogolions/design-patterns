using System;
using System.Threading;
using System.Threading.Tasks;

namespace Gof.Behavioral.TemplateMethod
{
    public abstract class BackgroundJob : IDisposable
    {
        private Task _executingTask;
        private CancellationTokenSource _cts;

        public virtual Task ExecutingTask => _executingTask;

        public Task RunAsync(CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            _cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
            _executingTask = ExecuteAsync(_cts.Token);
            return _executingTask.IsCompleted ? _executingTask : Task.CompletedTask;
        }

        protected abstract Task ExecuteAsync(CancellationToken token = default);

        public async Task StopAsync(CancellationToken token = default)
        {
            if (_executingTask is null) return;
            try
            {
                _cts?.Cancel();
            }
            finally
            {
                await Task.WhenAny(_executingTask, Task.Delay(Timeout.InfiniteTimeSpan));
            }
        }

        public void Dispose()
        {
            _cts?.Cancel();
        }
    }
}
