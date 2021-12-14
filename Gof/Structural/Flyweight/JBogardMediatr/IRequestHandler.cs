namespace Gof.Structural.Flyweight.JBogardMediatr
{
    public interface IRequestHandler<in TReq, out TRes> where TReq : IRequest<TRes>
    {
        TRes Handle(TReq request);
    }
}
