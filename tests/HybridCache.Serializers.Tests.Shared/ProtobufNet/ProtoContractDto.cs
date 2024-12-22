using ProtoBuf;

namespace HybridCache.Serializers.Tests.Shared.ProtobufNet;

[ProtoContract]
internal sealed record ProtoContractDto : IRandomizable<ProtoContractDto>
{
    [ProtoMember(1)] public required string Field1 { get; init; }
    [ProtoMember(2)] public required int Field2 { get; init; }
    [ProtoMember(3)] public required bool Field3 { get; init; }
    [ProtoMember(4)] public required double Field4 { get; init; }
    [ProtoMember(5)] public required (string, bool) Field5 { get; init; }
    
    public static ProtoContractDto Random()
    {
        var random = new Random();

        return new ProtoContractDto
        {
            Field1 = Guid.NewGuid().ToString(),
            Field2 = random.Next(),
            Field3 = random.Next() % 2 == 0,
            Field4 = random.NextDouble(),
            Field5 = (Guid.NewGuid().ToString(), random.Next() % 2 == 0)
        };
    }
}