using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using MemoryPack;
using Microsoft.Extensions.Caching.Hybrid;

namespace HybridCache.Serializers.MemoryPack;

public class MemoryPackSerializerFactory(MemoryPackSerializerOptions? options = null) : IHybridCacheSerializerFactory
{
    public bool TryCreateSerializer<T>([NotNullWhen(true)] out IHybridCacheSerializer<T>? serializer)
    {
        if (SupportsType<T>())
        {
            serializer = new MemoryPackSerializer<T>(options);
            return true;
        }

        serializer = null;
        return false;
    }

    protected virtual bool SupportsType<T>()
    {
        return typeof(T).GetCustomAttribute(typeof(MemoryPackableAttribute), false) is not null;
    }
}