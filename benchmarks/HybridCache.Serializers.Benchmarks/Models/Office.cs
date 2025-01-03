﻿using HybridCache.Serializers.Benchmarks.Core;
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
public sealed partial record Office(
    [property: Key(0), ProtoMember(1)] string CompanyName,
    [property: Key(1), ProtoMember(2)] string Address,
    [property: Key(2), ProtoMember(3)] List<Person> Employees
) : IParamsSourceProvider<Office>
{
    public static IEnumerable<Office> GetModels() => [Random(100), Random(1000), Random(10000)];

    public static IEnumerable<IHybridCacheSerializer<Office>> GetSerializers() =>
    [
        new MemoryPackSerializer<Office>(),
        new MessagePackSerializer<Office>(),
        new ProtobufNetSerializer<Office>(),
        new JsonSerializer<Office>()
    ];
    

    private static Office Random(int employeeCount)
    {
        var employees = Enumerable.Range(0, employeeCount)
            .Select(_ => Person.Random())
            .ToList();

        return new Office(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), employees);
    }
    
    public override string ToString() => $"Office({Employees.Count})";
}