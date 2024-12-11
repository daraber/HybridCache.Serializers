using System.Buffers;

namespace HybridCache.Serializers.ProtobufNet.Tests;

[TestOf(typeof(ProtobufNetSerializer<>))]
[Category("ProtobufNet")]
[Parallelizable(ParallelScope.All)]
public class ProtobufNetTests
{
    private ProtobufNetSerializer<ProtoContractDto> _memoryPackSerializer;

    [SetUp]
    public void SetUp()
    {
        _memoryPackSerializer = new ProtobufNetSerializer<ProtoContractDto>();
    }

    [Test]
    public void MemoryPackSerializer_SerializeAndDeserialize_ShouldBeEqual()
    {
        var dto = ProtoContractDto.Random();
        var target = new ArrayBufferWriter<byte>();
        _memoryPackSerializer.Serialize(dto, target);

        Assert.That(target.WrittenMemory.Length, Is.GreaterThan(0), "Serializer should write data");

        var deserializedDto = _memoryPackSerializer.Deserialize(new ReadOnlySequence<byte>(target.WrittenMemory));
        Assert.That(dto, Is.EqualTo(deserializedDto));
    }
}