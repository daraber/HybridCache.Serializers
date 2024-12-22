using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using MessagePack;
using Microsoft.Extensions.Caching.Hybrid;

namespace HybridCache.Serializers.MessagePack;

public class MessagePackSerializerFactory(MessagePackSerializerOptions? options = null) : IHybridCacheSerializerFactory
{
    public bool TryCreateSerializer<T>([NotNullWhen(true)] out IHybridCacheSerializer<T>? serializer)
    {
        if (SupportsType<T>())
        {
            serializer = new MessagePackSerializer<T>(options);
            return true;
        }

        serializer = null;
        return false;
    }

    protected virtual bool SupportsType<T>()
    {
        return typeof(T).GetCustomAttribute(typeof(MessagePackObjectAttribute), false) is not null;
    }
}