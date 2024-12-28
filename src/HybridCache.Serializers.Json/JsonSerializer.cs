using System;
using System.Buffers;
using System.Text.Json;
using Microsoft.Extensions.Caching.Hybrid;

namespace HybridCache.Serializers.Json;

public class JsonSerializer<T>(
    JsonSerializerOptions? serializerOptions = null,
    JsonReaderOptions? readerOptions = null,
    JsonWriterOptions? writerOptions = null
) : IHybridCacheSerializer<T>
{
    public T Deserialize(ReadOnlySequence<byte> source)
    {
        var reader = new Utf8JsonReader(source, readerOptions ?? default);
        var value = JsonSerializer.Deserialize<T>(ref reader, serializerOptions);
        
        return value ?? throw new InvalidOperationException("Deserialization returned null.");
    }

    public void Serialize(T value, IBufferWriter<byte> target)
    {
        using var writer = new Utf8JsonWriter(target, writerOptions ?? default);
        JsonSerializer.Serialize(writer, value, serializerOptions);
    }
}