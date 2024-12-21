using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Microsoft.Extensions.Caching.Hybrid;
using ProtoBuf;

namespace HybridCache.Serializers.ProtobufNet;

public class ProtobufNetSerializerFactory : IHybridCacheSerializerFactory
{
    public bool TryCreateSerializer<T>([NotNullWhen(true)] out IHybridCacheSerializer<T>? serializer)
    {
        if (SupportsType<T>())
        {
            serializer = new ProtobufNetSerializer<T>();
            return true;
        }

        serializer = null;
        return false;
    }

    protected virtual bool SupportsType<T>()
    {
        return typeof(T).GetCustomAttribute(typeof(ProtoContractAttribute), false) is not null;
    }
}