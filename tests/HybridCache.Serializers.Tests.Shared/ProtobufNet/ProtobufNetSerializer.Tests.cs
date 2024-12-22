using HybridCache.Serializers.ProtobufNet;
using HybridCache.Serializers.Tests.Shared.Internal;

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
        SerializerTestFixtureUtils.SerializeAndDeserialize_ShouldBeEqual(serializer);
    }
}