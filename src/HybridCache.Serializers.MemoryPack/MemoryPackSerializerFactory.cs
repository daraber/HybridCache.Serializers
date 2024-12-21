using System.Diagnostics.CodeAnalysis;
using MemoryPack;
using Microsoft.Extensions.Caching.Hybrid;

namespace HybridCache.Serializers.MemoryPack;

public class MemoryPackSerializerFactory : IHybridCacheSerializerFactory
{
    public bool TryCreateSerializer<T>([NotNullWhen(true)] out IHybridCacheSerializer<T>? serializer)
    {
        if (SupportsType<T>())
        {
            serializer = new MemoryPackSerializer<T>();
            return true;
        }

        serializer = null;
        return false;
    }

    protected virtual bool SupportsType<T>()
    {
        return typeof(T).GetCustomAttributes(typeof(MemoryPackableAttribute), false).Length > 0;
    }
}