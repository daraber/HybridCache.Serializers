using System.Buffers;
using MessagePack;

namespace HybridCache.Serializers.MessagePack.Tests;

[TestFixture]
[TestOf(typeof(MessagePackSerializer))]
[Category("MessagePack")]
[Parallelizable(ParallelScope.All)]
public class MessagePackSerializerTests
{
    private MessagePackSerializer<MessagePackObjectDto> _messagePackSerializer;

    [SetUp]
    public void SetUp()
    {
        _messagePackSerializer = new MessagePackSerializer<MessagePackObjectDto>();
    }

    [Test]
    public void MessagePackSerializer_SerializeAndDeserialize_ShouldBeEqual()
    {
        var dto = MessagePackObjectDto.Random();
        var target = new ArrayBufferWriter<byte>();
        _messagePackSerializer.Serialize(dto, target);

        Assert.That(target.WrittenMemory.Length, Is.GreaterThan(0), "Serializer should write data");

        var deserializedDto = _messagePackSerializer.Deserialize(new ReadOnlySequence<byte>(target.WrittenMemory));
        Assert.That(dto, Is.EqualTo(deserializedDto));
    }
}