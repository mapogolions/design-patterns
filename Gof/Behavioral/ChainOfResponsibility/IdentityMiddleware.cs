namespace Gof.Behavioral.ChainOfResponsibility
{
    // Identity means f: a -> a in FP paradigm
    public class IdentityMiddleware : Middleware
    {
        public override bool Check(string datum) => PassNext(datum);
    }
}
