using HybridCache.Serializers.ProtobufNet;

namespace HybridCache.Serializers.Tests.Shared.ProtobufNet;

[TestFixture]
[TestOf(typeof(ProtobufNetSerializerFactory))]
[Category("ProtobufNet")]
[Parallelizable(ParallelScope.All)]
public class ProtobufNetSerializerFactoryTests
{
    [Test]
    public void ProtobufNetSerializerFactory_TryCreateSerializer_WhenTypeHasProtoContract_ShouldReturnTrue()
    {
        var factory = new ProtobufNetSerializerFactory();
        SerializerFactoryTestFixtureUtils.SerializerFactory_ShouldSupportType<ProtoContractDto>(factory);
    }

    [Test]
    public void ProtobufNetSerializerFactory_TryCreateSerializer_WhenTypeMissesProtoContract_ShouldReturnFalse()
    {
        var factory = new ProtobufNetSerializerFactory();
        var types = new[]
        {
            typeof(Uri), typeof(string), typeof(int), typeof(bool), typeof(double), typeof((string, bool))
        };

        SerializerFactoryTestFixtureUtils.SerializerFactory_TryCreateSerializer_ShouldNotSupportTypes(factory, types);
    }
}