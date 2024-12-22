using HybridCache.Serializers.MessagePack;

namespace HybridCache.Serializers.Tests.Shared.MessagePack;

[TestFixture]
[TestOf(typeof(MessagePackSerializerFactory))]
[Category("MessagePack")]
[Parallelizable(ParallelScope.All)]
public class MessagePackSerializerFactoryTests
{
    [Test]
    public void MessagePackSerializerFactory_TryCreateSerializer_WhenTypeHasMessagePackObject_ShouldReturnTrue()
    {
        var factory = new MessagePackSerializerFactory();
        SerializerFactoryTestFixtureUtils.SerializerFactory_ShouldSupportType<MessagePackObjectDto>(factory);
    }

    [Test]
    public void MessagePackSerializerFactory_TryCreateSerializer_WhenTypeMissesMessagePackObject_ShouldReturnFalse()
    {
        var factory = new MessagePackSerializerFactory();
        var types = new[]
        {
            typeof(Uri), typeof(string), typeof(int), typeof(bool), typeof(double), typeof((string, bool))
        };

        SerializerFactoryTestFixtureUtils.SerializerFactory_TryCreateSerializer_ShouldNotSupportTypes(factory, types);
    }
}