using System.Buffers;

namespace HybridCache.Serializers.MemoryPack.Tests;

[TestOf(typeof(MemoryPackSerializer<>))]
[Category("MemoryPack")]
[Parallelizable(ParallelScope.All)]
public class MemoryPackTests
{
    private MemoryPackSerializer<MemoryPackableDto> _memoryPackSerializer;

    [SetUp]
    public void SetUp()
    {
        _memoryPackSerializer = new MemoryPackSerializer<MemoryPackableDto>();
    }

    [Test]
    public void MemoryPackSerializer_SerializeAndDeserialize_ShouldBeEqual()
    {
        var dto = MemoryPackableDto.Random();
        var target = new ArrayBufferWriter<byte>();
        _memoryPackSerializer.Serialize(dto, target);

        Assert.That(target.WrittenMemory.Length, Is.GreaterThan(0), "Serializer should write data");
        
        var deserializedDto = _memoryPackSerializer.Deserialize(new ReadOnlySequence<byte>(target.WrittenMemory));
        Assert.That(dto, Is.EqualTo(deserializedDto));
    }
}