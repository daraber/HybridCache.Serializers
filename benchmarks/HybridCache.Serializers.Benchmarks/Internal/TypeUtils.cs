namespace HybridCache.Serializers.Benchmarks.Internal;

internal static class TypeUtils
{
    public static string GetShortName(Type type, bool includeGeneric = true)
    {
        if (includeGeneric && type.IsGenericType)
        {
            var typeName = type.Name;
            var genericArguments = type.GetGenericArguments();
            var genericArgumentNames = string.Join(", ", genericArguments.Select(arg => arg.Name));
            return $"{typeName.Split('`')[0]}[{genericArgumentNames}]";
        }

        return type.Name.Split('`')[0];
    }
}