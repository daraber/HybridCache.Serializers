using HybridCache.Serializers.ProtobufNet;

namespace HybridCache.Serializers.Tests.Shared.ProtobufNet;

[TestFixture]
[TestOf(typeof(ProtobufNetSerializer<>))]
[Category("ProtobufNet")]
[Parallelizable(ParallelScope.All)]
public class ProtobufNetSerializer 
{
    [Test]
    public void ProtobufNetSerializer_SerializeAndDeserialize_ShouldBeEqual()
    {
        var serializer = new ProtobufNetSerializer<ProtoContractDto>();
        SerializerFixtureUtils.SerializeAndDeserialize_ShouldBeEqual(serializer);
    }
}