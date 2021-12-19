namespace Gof.Structural.Flyweight.JBogardMediatr
{
    public interface IEndpoint<in TReq, out TRes> where TReq : IRequest<TRes>
    {
        TRes Act(TReq request);
    }
}
