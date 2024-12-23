using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using HybridCache.Serializers.Benchmarks.Internal;

namespace HybridCache.Serializers.Benchmarks.Columns;

// Provides a shorter type name for the serializer(s) used in the benchmarks
public class TypeColumn : IColumn
{
    public string Id => nameof(TypeColumn);
    public string ColumnName => "Type";

    public bool AlwaysShow => true;
    public ColumnCategory Category => ColumnCategory.Params;
    public int PriorityInCategory => -1;
    public bool IsNumeric => false;
    public UnitType UnitType => UnitType.Dimensionless;
    public string Legend => "Type of the serializer used";

    public bool IsDefault(Summary summary, BenchmarkCase benchmarkCase) => false;
    public bool IsAvailable(Summary summary) => true;
    public override string ToString() => ColumnName;
    
    public string GetValue(Summary summary, BenchmarkCase benchmarkCase, SummaryStyle style) =>
        GetValue(summary, benchmarkCase);
    
    public string GetValue(Summary summary, BenchmarkCase benchmarkCase)
    {
        var serializer = benchmarkCase.Parameters["Serializer"];
        var type = serializer.GetType();
        
        return TypeUtils.GetShortName(type, false);
    }
}