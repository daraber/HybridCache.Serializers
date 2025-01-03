﻿using HybridCache.Serializers.MemoryPack;
using HybridCache.Serializers.Tests.Shared.Internal;

namespace HybridCache.Serializers.Tests.Shared.MemoryPack;

[TestFixture]
[TestOf(typeof(MemoryPackSerializer<>))]
[Category("MemoryPack")]
[Parallelizable(ParallelScope.All)]
public class MemoryPackSerializerTests
{
    [Test]
    public void MemoryPackSerializer_SerializeAndDeserialize_ShouldBeEqual()
    {
        var serializer = new MemoryPackSerializer<MemoryPackableDto>();
        SerializerTestFixtureUtils.SerializeAndDeserialize_ShouldBeEqual(serializer);
    }
}