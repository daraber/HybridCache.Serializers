using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using Microsoft.Extensions.Caching.Hybrid;

namespace HybridCache.Serializers.Json;

public class JsonSerializerFactory(
    JsonSerializerOptions? serializerOptions = null,
    JsonReaderOptions? readerOptions = null,
    JsonWriterOptions? writerOptions = null
) : IHybridCacheSerializerFactory
{
    public bool TryCreateSerializer<T>([NotNullWhen(true)] out IHybridCacheSerializer<T>? serializer)
    {
        if (SupportsType<T>())
        {
            serializer = new JsonSerializer<T>(serializerOptions, readerOptions, writerOptions);
            return true;
        }

        serializer = null;
        return false;
    }

    protected virtual bool SupportsType<T>() => true;
}