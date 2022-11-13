using System;
using Gof.Behavioral.Typeclass.Internal;

namespace Gof.Behavioral.Typeclass
{
    public interface ISerializer<T>
    {
        string Stringify(T obj);
    }

    public static class SerializerInstances
    {
        public static ISerializer<Arrow> ArrowSerializer = new ArrowSerializer();
        public static ISerializer<Klass> KlassSerializer = new KlassSerializer();
    }

    // approach 1
    public static class Serializer
    {
        public static string Serialize<T>(T node, ISerializer<T> serializer)=> serializer.Stringify(node);
    }

    // approach 2
    public static class SerializerExtensions
    {
        public static string Stringify<T>(this T obj, /** implicit in scala2 world **/ ISerializer<T> serializer)
        {
            if (obj is null) throw new ArgumentNullException(nameof(obj));
            return serializer.Stringify(obj);
        }

        public static string Stringify(this Arrow fn) // be like implicit in scala
        {
            if (fn is null) throw new ArgumentNullException(nameof(fn));
            return fn.Stringify(SerializerInstances.ArrowSerializer);
        }

        public static string Stringify(this Klass fn)
        {
            if (fn is null) throw new ArgumentNullException(nameof(fn));
            return fn.Stringify(SerializerInstances.KlassSerializer);
        }
    }
}
