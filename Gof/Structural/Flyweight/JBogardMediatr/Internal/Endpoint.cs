namespace Gof.Structural.Flyweight.JBogardMediatr.Internal
{
    internal abstract class UntypedEndpoint
    {
        public abstract object Act(object request, ServiceProvider services);
    }

    internal class TypedEndpoint<TReq, TRes> : UntypedEndpoint
        where TReq : IRequest<TRes>
    {
        public override object Act(object request, ServiceProvider services)
        {
            var endpoint = (IEndpoint<TReq, TRes>) services(typeof(IEndpoint<TReq, TRes>));
            return endpoint.Act((TReq) request);
        }
    }
}
