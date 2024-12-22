### Serializers

| Name                                                                    | Attribute         | Description                                         |
|-------------------------------------------------------------------------|-------------------|-----------------------------------------------------|
| [MemoryPack](https://github.com/Cysharp/MemoryPack)                     | MemoryPackable    | Zero encoding extreme performance binary serializer |
| [protobuf-net](https://github.com/protobuf-net/protobuf-net)            | ProtoContract     | Contract based protocol buffers serializer          |
| [MessagePack](https://github.com/MessagePack-CSharp/MessagePack-CSharp) | MessagePackObject | Extremely fast MessagePack serializer               |

### Notes

-`IHybridCacheSerializerFactory` implementations yield serializers for types with the respective serializer attribute by
default (e.g., `MemoryPackable` for MemoryPack). Override `SupportsType<T>()` to customize type support.
