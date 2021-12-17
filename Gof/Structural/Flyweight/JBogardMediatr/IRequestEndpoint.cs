namespace Gof.Structural.Flyweight.JBogardMediatr
{
    public interface IRequestEndpoint<in TReq, out TRes> where TReq : IRequest<TRes>
    {
        TRes Act(TReq request);
    }
}
