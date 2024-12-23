using Microsoft.Extensions.Caching.Hybrid;

namespace HybridCache.Serializers.Benchmarks.Core;

public interface IParamsSourceProvider<T>
{
    static abstract IEnumerable<T> GetModels();
    static abstract IEnumerable<IHybridCacheSerializer<T>> GetSerializers();
}