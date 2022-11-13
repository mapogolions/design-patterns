namespace Gof.Behavioral.Typeclass.Internal
{
    internal class KlassSerializer : ISerializer<Klass>
    {
        public string Stringify(Klass cls) => cls.Parent is null ? cls.Name : $"{cls.Name} < {Stringify(cls.Parent)}";
    }
}
