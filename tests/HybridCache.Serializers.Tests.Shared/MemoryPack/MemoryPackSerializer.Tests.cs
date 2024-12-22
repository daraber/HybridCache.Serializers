using HybridCache.Serializers.MemoryPack;

namespace HybridCache.Serializers.Tests.Shared.MemoryPack;

[TestFixture]
[TestOf(typeof(MemoryPackSerializer<>))]
[Category("MemoryPack")]
[Parallelizable(ParallelScope.All)]
public class MemoryPackSerializerTests
{
    [Test]
    public void MemoryPackSerializer_SerializeAndDeserialize_ShouldBeEqual()
    {
        var serializer = new MemoryPackSerializer<MemoryPackableDto>();
        SerializerFixtureUtils.SerializeAndDeserialize_ShouldBeEqual(serializer);
    }
}