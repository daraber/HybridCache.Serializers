using HybridCache.Serializers.Tests.Shared.Internal;

namespace HybridCache.Serializers.Tests.Shared.Json;

internal sealed record JsonDto(
    string Field1,
    int Field2,
    bool Field3,
    double Field4,
    (string, bool) Field5
) : IRandomizable<JsonDto>
{
    public static JsonDto Random()
    {
        var random = new Random();

        return new JsonDto(
            Guid.NewGuid().ToString(),
            random.Next(),
            random.Next() % 2 == 0,
            random.NextDouble(),
            (Guid.NewGuid().ToString(), random.Next() % 2 == 0)
        );
    }
}