using System.Buffers;

namespace HybridCache.Serializers.ProtobufNet.Tests;

[TestOf(typeof(ProtobufNetSerializer<>))]
[Category("ProtobufNet")]
[Parallelizable(ParallelScope.All)]
public class ProtobufNetTests
{
    private ProtobufNetSerializer<ProtoContractDto> _protobufNetSerializer;

    [SetUp]
    public void SetUp()
    {
        _protobufNetSerializer = new ProtobufNetSerializer<ProtoContractDto>();
    }

    [Test]
    public void ProtobufNetSerializer_SerializeAndDeserialize_ShouldBeEqual()
    {
        var dto = ProtoContractDto.Random();
        var target = new ArrayBufferWriter<byte>();
        _protobufNetSerializer.Serialize(dto, target);

        Assert.That(target.WrittenMemory.Length, Is.GreaterThan(0), "Serializer should write data");

        var deserializedDto = _protobufNetSerializer.Deserialize(new ReadOnlySequence<byte>(target.WrittenMemory));
        Assert.That(dto, Is.EqualTo(deserializedDto));
    }
}