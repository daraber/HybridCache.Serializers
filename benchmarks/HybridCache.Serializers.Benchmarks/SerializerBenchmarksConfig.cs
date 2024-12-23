﻿using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Order;
using BenchmarkDotNet.Toolchains.InProcess.Emit;
using HybridCache.Serializers.Benchmarks.Columns;

namespace HybridCache.Serializers.Benchmarks;

public class SerializerBenchmarksConfig : ManualConfig
{
    public SerializerBenchmarksConfig()
    {
        HideColumns("Serializer"); // Serializer column specifies serializer names incl. redundant namespace
        AddColumn(new TypeColumn(),  StatisticColumn.P95);
        
        AddExporter(CsvExporter.Default);
        AddExporter(MarkdownExporter.GitHub);

        AddLogicalGroupRules(BenchmarkLogicalGroupRule.ByMethod);
        AddJob(Job.MediumRun.WithToolchain(InProcessEmitToolchain.Instance));
        WithOrderer(new DefaultOrderer(summaryOrderPolicy: SummaryOrderPolicy.FastestToSlowest));
    }
}