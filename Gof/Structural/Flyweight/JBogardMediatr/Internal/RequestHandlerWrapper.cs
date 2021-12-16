namespace Gof.Structural.Flyweight.JBogardMediatr.Internal
{
    internal abstract class RequestHandlerBase
    {
        public abstract object Handle(object request, ServiceProvider services);
    }

    internal class RequestHandlerWrapper<TReq, TRes> : RequestHandlerBase
        where TReq : IRequest<TRes>
    {
        public override object Handle(object request, ServiceProvider services)
        {
            var handler = (IRequestHandler<TReq, TRes>) services(typeof(IRequestHandler<TReq, TRes>));
            return handler.Handle((TReq) request);
        }
    }
}
