using BenchmarkDotNet.Attributes;
using HybridCache.Serializers.Benchmarks.Core;
using HybridCache.Serializers.Benchmarks.Models;

namespace HybridCache.Serializers.Benchmarks;

[Config(typeof(SerializerBenchmarksConfig))]
public class OfficeSerializerBenchmarks : SerializerBenchmarksBase<Office>;

[Config(typeof(SerializerBenchmarksConfig))]
public class PersonSerializerBenchmarks : SerializerBenchmarksBase<Person>;

[Config(typeof(SerializerBenchmarksConfig))]
public class ComplexPersonSerializerBenchmarks : SerializerBenchmarksBase<ComplexPerson>;