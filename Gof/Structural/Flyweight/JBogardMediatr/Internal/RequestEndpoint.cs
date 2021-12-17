namespace Gof.Structural.Flyweight.JBogardMediatr.Internal
{
    internal abstract class UntypedRequestEndpoint
    {
        public abstract object Act(object request, ServiceProvider services);
    }

    internal class TypedRequestEndpoint<TReq, TRes> : UntypedRequestEndpoint
        where TReq : IRequest<TRes>
    {
        public override object Act(object request, ServiceProvider services)
        {
            var endpoint = (IRequestEndpoint<TReq, TRes>) services(typeof(IRequestEndpoint<TReq, TRes>));
            return endpoint.Act((TReq) request);
        }
    }
}
