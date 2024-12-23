using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Reports;
using HybridCache.Serializers.Benchmarks.Core;

namespace HybridCache.Serializers.Benchmarks.Internal;

internal class SerializedSizeExporter : IExporter
{
    public string Name => nameof(SerializedSizeExporter);

    public void ExportToLog(Summary summary, ILogger logger)
    {
        foreach (var ((serializer, model), size) in SerializerBenchmarksBase.SerializedModelSizes)
        {
            logger.WriteLine($"{serializer} - {model} => {size} bytes");
        }
    }

    public IEnumerable<string> ExportToFiles(Summary summary, ILogger consoleLogger)
    {
        var lines = new List<string>();
        
        foreach (var ((serializer, model), size) in SerializerBenchmarksBase.SerializedModelSizes)
        {
            lines.Add($"{serializer} - {model} => {size} bytes");
        }
        
        return lines;
    }
}