using System.Buffers;
using Microsoft.Extensions.Caching.Hybrid;

namespace HybridCache.Serializers.Tests.Shared;

internal static class SerializerFixtureUtils
{
    public static void SerializeAndDeserialize_ShouldBeEqual<T>(IHybridCacheSerializer<T> serializer)
        where T : class, IEquatable<T>, IRandomizable<T>
    {
        var dto = T.Random();
        Assert.That(dto, Is.Not.Null);

        var target = new ArrayBufferWriter<byte>();
        serializer.Serialize(dto, target);

        Assert.That(target.WrittenMemory.Length, Is.GreaterThan(0), "Serializer should write data");

        var deserializedDto = serializer.Deserialize(new ReadOnlySequence<byte>(target.WrittenMemory));
        Assert.That(dto, Is.EqualTo(deserializedDto));
    }
}