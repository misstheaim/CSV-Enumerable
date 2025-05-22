namespace CSV_Enumerable.Attributes;

internal class CsvMapAttribute : Attribute
{
    public Type CsvMapType { get; }

    public CsvMapAttribute(Type type)
    {
        CsvMapType = type;
    }
}
