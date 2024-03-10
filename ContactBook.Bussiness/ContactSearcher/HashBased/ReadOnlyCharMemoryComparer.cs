namespace ContactBook.Bussiness.HashBased;

public class ReadOnlyCharMemoryComparer : IEqualityComparer<ReadOnlyMemory<char>>
{
    private readonly StringComparison _comparison;
    public ReadOnlyCharMemoryComparer(StringComparison comparison = StringComparison.Ordinal)
    {
        _comparison = comparison;
    }
    
    public bool Equals(ReadOnlyMemory<char> x, ReadOnlyMemory<char> y)
    {
        return x.Span.Equals(y.Span, _comparison);
    }

    public int GetHashCode(ReadOnlyMemory<char> obj)
    {
        return string.GetHashCode(obj.Span, _comparison);
    }
}