namespace HybridCache.Serializers.Tests.Shared;

public interface IRandomizable<out T>
{
    static abstract T Random();
}