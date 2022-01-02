using System;

namespace Gof.Structural.Adapter.FunctionalInterface
{
    public class PreProcessorAdapter<TRequest> : IPreProcessor<TRequest>
    {
        private readonly Action<TRequest> _action;

        public PreProcessorAdapter(Action<TRequest> action) => _action = action;

        public void Process(TRequest request) => _action(request);
    }
}
