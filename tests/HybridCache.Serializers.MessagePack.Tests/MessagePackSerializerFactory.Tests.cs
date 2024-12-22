namespace HybridCache.Serializers.MessagePack.Tests;

[TestFixture]
[TestOf(typeof(MessagePackSerializerFactory))]
[Category("MessagePack")]
[Parallelizable(ParallelScope.All)]
public class MessagePackSerializerFactoryTests
{
    [Test]
    public void MessagePackSerializerFactory_TryCreateSerializer_WhenTypeIsMessagePackObject_ShouldReturnTrue()
    {
        var factory = new MessagePackSerializerFactory();
        var result = factory.TryCreateSerializer<MessagePackObjectDto>(out var serializer);

        Assert.Multiple(() =>
        {
            Assert.That(result, Is.True, "Serializer factory should support types with the MessagePackObject attribute");
            Assert.That(serializer, Is.Not.Null, "Serializer should not be null");
        });
    }

    [Test]
    public void MessagePackSerializerFactory_TryCreateSerializer_WhenTypeIsMessagePackObject_ShouldReturnFalse()
    {
        var factory = new MessagePackSerializerFactory();
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