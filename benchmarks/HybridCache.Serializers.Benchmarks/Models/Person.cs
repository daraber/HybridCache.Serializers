using HybridCache.Serializers.Benchmarks.Core;
using HybridCache.Serializers.MemoryPack;
using HybridCache.Serializers.MessagePack;
using HybridCache.Serializers.ProtobufNet;
using MemoryPack;
using MessagePack;
using Microsoft.Extensions.Caching.Hybrid;
using ProtoBuf;

namespace HybridCache.Serializers.Benchmarks.Models;

[MessagePackObject]
[MemoryPackable]
[ProtoContract(SkipConstructor = true)]
public sealed partial record Person(
    [property: Key(0), ProtoMember(1)] string Name,
    [property: Key(1), ProtoMember(2)] int Age,
    [property: Key(2), ProtoMember(3)] double Height
) : IParamsSourceProvider<Person>
{
    public static Person Random()
    {
        var random = new Random();

        return new Person(
            Name: Guid.NewGuid().ToString(),
            Age: random.Next(1, 100),
            Height: random.NextDouble() * 100
        );
    }

    public static IEnumerable<Person> GetModels() => [Random()];

    public static IEnumerable<IHybridCacheSerializer<Person>> GetSerializers() =>
    [
        new MemoryPackSerializer<Person>(),
        new MessagePackSerializer<Person>(),
        new ProtobufNetSerializer<Person>()
    ];

    public override string ToString() => "Person(1)";
}