using System.Buffers;
using MemoryPack;
using Microsoft.Extensions.Caching.Hybrid;

namespace HybridCache.Serializers.MemoryPack;

public class MemoryPackSerializer<T>(MemoryPackSerializerOptions? options = null)
    : IHybridCacheSerializer<T>
{
    public T Deserialize(ReadOnlySequence<byte> source)
    {
        return MemoryPackSerializer.Deserialize<T>(source, options) ?? default(T)!;
    }

    public void Serialize(T value, IBufferWriter<byte> target)
    {
        MemoryPackSerializer.Serialize(target, value, options);
    }
}