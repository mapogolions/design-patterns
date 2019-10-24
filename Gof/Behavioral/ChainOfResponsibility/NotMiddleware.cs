namespace Gof.Behavioral.ChainOfResponsibility
{
    public class NotMiddleware : Middleware
    {
        public override bool Check(string datum) => !PassNext(datum);
    }
}
