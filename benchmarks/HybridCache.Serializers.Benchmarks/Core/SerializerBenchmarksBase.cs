using System.Buffers;
using BenchmarkDotNet.Attributes;
using HybridCache.Serializers.Benchmarks.Internal;
using Microsoft.Extensions.Caching.Hybrid;

namespace HybridCache.Serializers.Benchmarks.Core;

public abstract class SerializerBenchmarksBase
{
    // Hacky way to expose serialized sizes 
    // ReSharper disable once StaticMemberInGenericType
    public static Dictionary<(string serializer, string model), long> SerializedModelSizes { get; } = new();
}

public abstract class SerializerBenchmarksBase<T> : SerializerBenchmarksBase where T : class, IParamsSourceProvider<T>
{
    [ParamsSource(nameof(GetSerializers))] public required IHybridCacheSerializer<T> Serializer { get; set; }
    [ParamsSource(nameof(GetModels))] public required T Model { get; set; }

    private ReadOnlySequence<byte> _serializedItem;

    [GlobalSetup]
    public void Setup()
    {
        var target = new ArrayBufferWriter<byte>();
        Serializer.Serialize(Model, target);
        _serializedItem = new ReadOnlySequence<byte>(target.WrittenMemory);

        var serializerName = TypeUtils.GetShortName(Serializer.GetType(), false);
        var modelName = Model.ToString()!;
        SerializedModelSizes[(serializerName, modelName)] = target.WrittenMemory.Length;
    }

    [GlobalCleanup]
    public void Cleanup()
    {
        var deserialized = Serializer.Deserialize(_serializedItem);
        
        if (!Model.Equals(deserialized))
        {
            var serializerName = TypeUtils.GetShortName(Serializer.GetType());
            throw new InvalidOperationException(
                $"{serializerName}: Deserialized model is not equal to the original model."
            );
        }
    }

    [Benchmark(OperationsPerInvoke = 1)]
    public virtual void Serialize()
    {
        var target = new ArrayBufferWriter<byte>();
        Serializer.Serialize(Model, target);
    }

    [Benchmark(OperationsPerInvoke = 1)]
    public virtual void Deserialize()
    {
        Serializer.Deserialize(_serializedItem);
    }

    public static IEnumerable<IHybridCacheSerializer<T>> GetSerializers() => T.GetSerializers();
    public static IEnumerable<T> GetModels() => T.GetModels();
}