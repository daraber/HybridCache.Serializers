namespace HybridCache.Serializers.Tests.Shared.Internal;

internal interface IRandomizable<out T>
{
    static abstract T Random();
}