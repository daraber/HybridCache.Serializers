using HybridCache.Serializers.Tests.Shared.Internal;
using MessagePack;

namespace HybridCache.Serializers.Tests.Shared.MessagePack;

[MessagePackObject(AllowPrivate = true)]
internal sealed record MessagePackObjectDto(
    [property: Key(0)] string Field1,
    [property: Key(1)] int Field2,
    [property: Key(2)] bool Field3,
    [property: Key(3)] double Field4,
    [property: Key(4)] (string, bool) Field5
) : IRandomizable<MessagePackObjectDto>
{
    public static MessagePackObjectDto Random()
    {
        var random = new Random();

        return new MessagePackObjectDto(
            Guid.NewGuid().ToString(),
            random.Next(),
            random.NextDouble() > 0.5,
            random.NextDouble(),
            (Guid.NewGuid().ToString(), random.NextDouble() > 0.5)
        );
    }
}