using Microsoft.Extensions.Caching.Hybrid;

namespace HybridCache.Serializers.Tests.Shared;

internal static class SerializerFactoryTestFixtureUtils
{
    public static void SerializerFactory_ShouldSupportType<T>(IHybridCacheSerializerFactory factory)
    {
        var result = factory.TryCreateSerializer<T>(out var serializer);

        Assert.Multiple(() =>
        {
            Assert.That(result, Is.True, $"Serializer factory should support type {typeof(T).Name}");
            Assert.That(serializer, Is.Not.Null, $"Serializer for type {typeof(T).Name} should not be null");
        });
    }
    
    public static void SerializerFactory_TryCreateSerializer_ShouldNotSupportTypes(
        IHybridCacheSerializerFactory factory,
        params Type[] types
    )
    {
        var tryCreateSerializerMethod = factory.GetType().GetMethod("TryCreateSerializer");
        Assert.That(tryCreateSerializerMethod, Is.Not.Null, "Method TryCreateSerializer should exist");
        
        var serializers = new Dictionary<Type, (bool canSerialize, object? serializer)>();

        foreach (var type in types)
        {
            var method = tryCreateSerializerMethod!.MakeGenericMethod(type);
            var parameters = new object?[] { null };
            
            var canSerialize = (bool)method.Invoke(factory, parameters)!;
            var serializer = parameters[0];
       
            serializers[type] = (canSerialize, serializer);
        }

        foreach (var (type, (result, serializer)) in serializers)
        {
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.False, $"Type {type.Name} should not be supported by serializer factory");
                Assert.That(serializer, Is.Null, $"Serializer for type {type.Name} should be null");
            });
        }
    }
}