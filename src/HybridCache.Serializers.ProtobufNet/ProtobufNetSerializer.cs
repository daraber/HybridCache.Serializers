using System.Buffers;
using Microsoft.Extensions.Caching.Hybrid;
using ProtoBuf;

namespace HybridCache.Serializers.ProtobufNet;

public class ProtobufNetSerializer<T> : IHybridCacheSerializer<T>
{
    public T Deserialize(ReadOnlySequence<byte> source)
    {
        return Serializer.Deserialize<T>(source);
    }

    public void Serialize(T value, IBufferWriter<byte> target)
    {
        Serializer.Serialize(target, value);
    }
}