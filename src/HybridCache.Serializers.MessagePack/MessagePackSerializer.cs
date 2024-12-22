using System.Buffers;
using MessagePack;
using Microsoft.Extensions.Caching.Hybrid;

namespace HybridCache.Serializers.MessagePack;

public class MessagePackSerializer<T>(MessagePackSerializerOptions? options = null) : IHybridCacheSerializer<T>
{
    public T Deserialize(ReadOnlySequence<byte> source)
    {
        return MessagePackSerializer.Deserialize<T>(source, options);
    }

    public void Serialize(T value, IBufferWriter<byte> target)
    {
        MessagePackSerializer.Serialize(target, value, options);
    }
}