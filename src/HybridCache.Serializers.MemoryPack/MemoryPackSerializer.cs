using System.Buffers;
using MemoryPack;
using Microsoft.Extensions.Caching.Hybrid;

namespace HybridCache.Serializers.MemoryPack;

public class MemoryPackSerializer<T>(MemoryPackSerializerOptions? serializerOptions = null)
    : IHybridCacheSerializer<T>
{
    public T Deserialize(ReadOnlySequence<byte> source)
    {
        return MemoryPackSerializer.Deserialize<T>(source, serializerOptions) ?? default(T)!;
    }

    public void Serialize(T value, IBufferWriter<byte> target)
    {
        MemoryPackSerializer.Serialize(target, value, serializerOptions);
    }
}