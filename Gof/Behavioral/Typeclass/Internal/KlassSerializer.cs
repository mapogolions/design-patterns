namespace Gof.Behavioral.Typeclass.Internal
{
    internal class KlassSerializer : ISerializer<Klass>
    {
        public string Serialize(Klass cls) => cls.Parent is null ? cls.Name : $"{cls.Name} < {Serialize(cls.Parent)}";
    }
}
