### Serializers

| Name                                                                    | Attribute         | Description                                         |
|:------------------------------------------------------------------------|-------------------|-----------------------------------------------------|
| [MemoryPack](https://github.com/Cysharp/MemoryPack)                     | MemoryPackable    | Zero encoding extreme performance binary serializer |
| [MessagePack](https://github.com/MessagePack-CSharp/MessagePack-CSharp) | MessagePackObject | Extremely fast MessagePack serializer               |
| [protobuf-net](https://github.com/protobuf-net/protobuf-net)            | ProtoContract     | Contract based protocol buffers serializer          |

---

### Benchmarks

Benchmark results will vary on different systems and environments. Conduct your own benchmarks to evaluate performance
for your use case if warranted. Note that serializers produce varying byte sizes which impact performance and storage,
thus speed is not universally the best measure for success.

**Environment**: .NET SDK 9.0.1, Windows 11, i9-10900 CPU 2.80GHz

![BenchmarkPerson](https://github.com/user-attachments/assets/4d3400e8-1783-4c4b-b1d3-5d54522a1e59)
*Benchmarks when (de)serializing a tiny [Person](benchmarks/HybridCache.Serializers.Benchmarks/Models/Person.cs) object.*

![BenchmarkOffice](https://github.com/user-attachments/assets/ef263625-b827-49dc-886d-44739bf49a19)
*Benchmarks when (de)serializing a large [Office](benchmarks/HybridCache.Serializers.Benchmarks/Models/Office.cs) object with 1000 [Person](benchmarks/HybridCache.Serializers.Benchmarks/Models/Person.cs) children.*


---

### Notes

* `IHybridCacheSerializerFactory` implementations yield serializers for types with the respective serializer attribute
  by default (e.g., `MemoryPackable` for MemoryPack). Override `SupportsType<T>()` to customize type support.
