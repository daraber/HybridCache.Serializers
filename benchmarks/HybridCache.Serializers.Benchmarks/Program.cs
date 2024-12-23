using BenchmarkDotNet.Running;
using HybridCache.Serializers.Benchmarks.Core;

BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);

Console.WriteLine("Serialized model sizes:");
foreach (var ((serializer, model), size) in SerializerBenchmarksBase.SerializedModelSizes)
{
    Console.WriteLine($"{serializer} - {model} => {size} bytes");
}