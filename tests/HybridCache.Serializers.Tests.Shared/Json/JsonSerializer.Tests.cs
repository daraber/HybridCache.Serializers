using System.Text.Json;
using HybridCache.Serializers.Json;
using HybridCache.Serializers.Tests.Shared.Internal;

namespace HybridCache.Serializers.Tests.Shared.Json;

[TestFixture]
[TestOf(typeof(JsonSerializer<>))]
[Category("Json")]
[Parallelizable(ParallelScope.All)]
public class JsonSerializerTests
{
    [Test]
    public void JsonSerializer_SerializeAndDeserialize_ShouldBeEqual()
    {
        var serializerOptions = new JsonSerializerOptions
        {
            IncludeFields = true,
        };

        var serializer = new JsonSerializer<JsonDto>(serializerOptions);
        SerializerTestFixtureUtils.SerializeAndDeserialize_ShouldBeEqual(serializer);
    }
}