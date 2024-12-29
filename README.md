### Serializers

| Name                                                                    | Attribute         | Description                                                               |
|:------------------------------------------------------------------------|-------------------|---------------------------------------------------------------------------|
| [MemoryPack](https://github.com/Cysharp/MemoryPack)                     | MemoryPackable    | Zero encoding extreme performance binary serializer                       |
| [MessagePack](https://github.com/MessagePack-CSharp/MessagePack-CSharp) | MessagePackObject | Extremely fast MessagePack serializer                                     |
| [protobuf-net](https://github.com/protobuf-net/protobuf-net)            | ProtoContract     | Contract based protocol buffers serializer                                |
| [Json](https://learn.microsoft.com/en-us/dotnet/api/system.text.json)   |                   | High-performance, low-allocating, and standards-compliant JSON serializer |

---

### Benchmarks

Serializers produce varying byte sizes which impact performance and storage, thus speed is not universally the best
measure for success.  Benchmark results will vary on
different systems and environments so conduct your own benchmarks to evaluate performance for your use case if
warranted. Note that *Memory Allocation* refers to the serialize output byte size.

**Environment**: .NET SDK 9.0.1, Windows 11, i9-10900 CPU 2.80GHz

![BenchmarkPerson](https://github.com/user-attachments/assets/11ce8376-9b0e-4d84-9e48-d1b0d0e6fe31)
<br/> <a name="BenchmarkPerson"><sup>[1]</sup></a> *Benchmarks when
de/serializing [Person](benchmarks/HybridCache.Serializers.Benchmarks/Models/Person.cs).*

![BenchmarkComplexPerson](https://github.com/user-attachments/assets/1e66abea-8828-4feb-9d61-ab1f00194338)
<br/> <a name="BenchmarkComplexPerson"><sup>[2]</sup></a> *Benchmarks when
de/serializing [ComplexPerson](benchmarks/HybridCache.Serializers.Benchmarks/Models/ComplexPerson.cs).*

![BenchmarkOffice](https://github.com/user-attachments/assets/482ca485-aa40-4185-b714-e6270c91dac5)
<br/> <a name="BenchmarkOffice"><sup>[3]</sup></a> *Benchmarks when de/serializing
an [Office](benchmarks/HybridCache.Serializers.Benchmarks/Models/Office.cs) with
1000 [Person](benchmarks/HybridCache.Serializers.Benchmarks/Models/Person.cs) children.*

---

### Notes

* `IHybridCacheSerializerFactory` implementations yield serializers for types with the respective serializer attribute
  by default (e.g., `MemoryPackable` for MemoryPack). Override `SupportsType<T>()` to customize type support.
