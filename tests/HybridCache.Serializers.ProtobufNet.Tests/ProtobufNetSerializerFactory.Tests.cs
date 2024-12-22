namespace HybridCache.Serializers.ProtobufNet.Tests;

[TestFixture]
[TestOf(typeof(ProtobufNetSerializerFactory))]
[Category("ProtobufNet")]
[Parallelizable(ParallelScope.All)]
public class ProtobufNetSerializerFactoryTests
{
    [Test]
    public void ProtobufNetSerializerFactory_TryCreateSerializer_WhenTypeIsProtoContract_ShouldReturnTrue()
    {
        var factory = new ProtobufNetSerializerFactory();
        var result = factory.TryCreateSerializer<ProtoContractDto>(out var serializer);

        Assert.Multiple(() =>
        {
            Assert.That(result, Is.True, "Serializer factory should support types with the ProtoContract attribute");
            Assert.That(serializer, Is.Not.Null, "Serializer should not be null");
        });
    }

    [Test]
    public void ProtobufNetSerializerFactory_TryCreateSerializer_WhenTypeIsNotProtoContract_ShouldReturnFalse()
    {
        var factory = new ProtobufNetSerializerFactory();
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