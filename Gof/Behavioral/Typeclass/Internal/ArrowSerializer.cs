namespace Gof.Behavioral.Typeclass.Internal;

internal class ArrowSerializer : ISerializer<Arrow>
{
    public string Stringify(Arrow fn) => $"val {fn.Name} : {fn.Domain} -> {fn.Codomain} = fun";
}
