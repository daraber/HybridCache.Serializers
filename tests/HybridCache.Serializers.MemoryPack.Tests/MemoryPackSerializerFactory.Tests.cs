namespace HybridCache.Serializers.MemoryPack.Tests;

[TestFixture]
[TestOf(typeof(MemoryPackSerializerFactory))]
[Category("MemoryPack")]
[Parallelizable(ParallelScope.All)]
public class MemoryPackSerializerFactoryTests
{
    [Test]
    public void MemoryPackSerializerFactory_TryCreateSerializer_WhenTypeIsMemoryPackable_ShouldReturnTrue()
    {
        var factory = new MemoryPackSerializerFactory();
        var result = factory.TryCreateSerializer<MemoryPackableDto>(out var serializer);

        Assert.Multiple(() =>
        {
            Assert.That(result, Is.True, "Serializer factory should support types with the MemoryPackable attribute");
            Assert.That(serializer, Is.Not.Null, "Serializer should not be null");
        });
    }

    [Test]
    public void MemoryPackSerializerFactory_TryCreateSerializer_WhenTypeIsNotMemoryPackable_ShouldReturnFalse()
    {
        var factory = new MemoryPackSerializerFactory();
        var tryCreateSerializerMethod = factory.GetType().GetMethod("TryCreateSerializer");
        Assert.That(tryCreateSerializerMethod, Is.Not.Null, "Method TryCreateSerializer should exist");

        var results = new List<bool>();
        var serializers = new Dictionary<object, object?>();

        var types = new[]
        {
            typeof(Uri), typeof(string), typeof(int), typeof(bool), typeof(double), typeof((string, bool))
        };

        foreach (var type in types)
        {
            var method = tryCreateSerializerMethod!.MakeGenericMethod(type);
            var parameters = new object?[] { null };
            var result = (bool)method.Invoke(factory, parameters)!;
            results.Add(result);
            serializers[type] = parameters[0];
        }

        foreach (var (type, result) in types.Zip(results, (type, result) => (type, result)))
        {
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.False, $"Type {type.Name} should not be supported by serializer factory");
                Assert.That(serializers[type], Is.Null, $"Serializer for type {type.Name} should be null");
            });
        }
    }
}