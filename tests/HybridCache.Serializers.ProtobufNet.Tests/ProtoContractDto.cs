using ProtoBuf;

namespace HybridCache.Serializers.ProtobufNet.Tests;

[ProtoContract]
internal sealed record ProtoContractDto
{
    [ProtoMember(1)] public required string Field1 { get; init; }
    [ProtoMember(2)] public required int Field2 { get; init; }
    [ProtoMember(3)] public required bool Field3 { get; init; }
    [ProtoMember(4)] public required double Field4 { get; init; }
    [ProtoMember(5)] public required (string, bool) Field5 { get; init; }
    
    public static ProtoContractDto Random()
    {
        var rand = new Random();

        return new ProtoContractDto
        {
            Field1 = Guid.NewGuid().ToString(),
            Field2 = rand.Next(),
            Field3 = rand.Next() % 2 == 0,
            Field4 = rand.NextDouble(),
            Field5 = (Guid.NewGuid().ToString(), rand.Next() % 2 == 0)
        };
    }
}