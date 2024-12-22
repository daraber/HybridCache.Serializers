using HybridCache.Serializers.MessagePack;
using MessagePack;

namespace HybridCache.Serializers.Tests.Shared.MessagePack;

[TestFixture]
[TestOf(typeof(MessagePackSerializer))]
[Category("MessagePack")]
[Parallelizable(ParallelScope.All)]
public class MessagePackSerializerTests
{
    [Test]
    public void MessagePackSerializer_SerializeAndDeserialize_ShouldBeEqual()
    {
        var serializer = new MessagePackSerializer<MessagePackObjectDto>();
        SerializerFixtureUtils.SerializeAndDeserialize_ShouldBeEqual(serializer);
    }
}