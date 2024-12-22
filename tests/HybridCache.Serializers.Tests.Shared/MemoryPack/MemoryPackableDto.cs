using HybridCache.Serializers.Tests.Shared.Internal;
using MemoryPack;

namespace HybridCache.Serializers.Tests.Shared.MemoryPack;

[MemoryPackable]
internal sealed partial record MemoryPackableDto(
    string Field1,
    int Field2,
    bool Field3,
    double Field4,
    (string, bool) Field5
) : IRandomizable<MemoryPackableDto>
{
    public static MemoryPackableDto Random()
    {
        var random = new Random();

        return new MemoryPackableDto(
            Guid.NewGuid().ToString(),
            random.Next(),
            random.Next() % 2 == 0,
            random.NextDouble(),
            (Guid.NewGuid().ToString(), random.Next() % 2 == 0)
        );
    }
}