using HybridCache.Serializers.MemoryPack;
using HybridCache.Serializers.Tests.Shared.Internal;

namespace HybridCache.Serializers.Tests.Shared.MemoryPack;

[TestFixture]
[TestOf(typeof(MemoryPackSerializerFactory))]
[Category("MemoryPack")]
[Parallelizable(ParallelScope.All)]
public class MemoryPackSerializerFactoryTests
{
    [Test]
    public void MemoryPackSerializerFactory_TryCreateSerializer_WhenTypeHasMemoryPackable_ShouldReturnTrue()
    {
        var factory = new MemoryPackSerializerFactory();
        SerializerFactoryTestFixtureUtils.SerializerFactory_ShouldSupportType<MemoryPackableDto>(factory);
    }

    [Test]
    public void MemoryPackSerializerFactory_TryCreateSerializer_WhenTypeMissesNotMemoryPackable_ShouldReturnFalse()
    {
        var factory = new MemoryPackSerializerFactory();
        var types = new[]
        {
            typeof(Uri), typeof(string), typeof(int), typeof(bool), typeof(double), typeof((string, bool))
        };

        SerializerFactoryTestFixtureUtils.SerializerFactory_TryCreateSerializer_ShouldNotSupportTypes(factory, types);
    }
}