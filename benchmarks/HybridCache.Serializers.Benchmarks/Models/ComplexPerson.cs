using HybridCache.Serializers.Benchmarks.Core;
using HybridCache.Serializers.Json;
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
public sealed partial record ComplexPerson(
    [property: Key(0), ProtoMember(1)] string Name,
    [property: Key(1), ProtoMember(2)] int Age,
    [property: Key(2), ProtoMember(3)] double Height,
    [property: Key(3), ProtoMember(4)] string Address,
    [property: Key(4), ProtoMember(5)] string PhoneNumber,
    [property: Key(5), ProtoMember(6)] string Email,
    [property: Key(6), ProtoMember(7)] DateTime DateOfBirth,
    [property: Key(7), ProtoMember(8)] bool IsActive,
    [property: Key(8), ProtoMember(9)] List<string> Tags,
    [property: Key(9), ProtoMember(10)] Dictionary<string, string> Metadata
) : IParamsSourceProvider<ComplexPerson>
{
    public static ComplexPerson Random()
    {
        var random = new Random();

        return new ComplexPerson(
            Name: Guid.NewGuid().ToString(),
            Age: random.Next(1, 100),
            Height: random.NextDouble() * 100,
            Address: Guid.NewGuid().ToString(),
            PhoneNumber: Guid.NewGuid().ToString(),
            Email: Guid.NewGuid().ToString(),
            DateOfBirth: DateTime.Now.AddYears(-random.Next(1, 100)),
            IsActive: random.Next(0, 2) == 1,
            Tags: ["tag1", "tag2"],
            Metadata: new Dictionary<string, string> { { "key1", Guid.NewGuid().ToString() }, { "key2", Guid.NewGuid().ToString() } }
        );
    }

    public static IEnumerable<ComplexPerson> GetModels() => [Random()];

    public static IEnumerable<IHybridCacheSerializer<ComplexPerson>> GetSerializers() =>
    [
        new MemoryPackSerializer<ComplexPerson>(),
        new MessagePackSerializer<ComplexPerson>(),
        new ProtobufNetSerializer<ComplexPerson>(),
        new JsonSerializer<ComplexPerson>()
    ];

    public override string ToString() => "ComplexPerson";
}