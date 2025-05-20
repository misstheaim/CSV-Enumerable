using CSV_Enumerable.Models;
using System.Collections;

namespace CSV_Enumerable.Services;

internal class CsvEnumerable : IEnumerable<Pet>
{
    private string _filePath;

    public CsvEnumerable(string filePath)
    {
        _filePath = filePath;
    }

    public IEnumerator<Pet> GetEnumerator()
    {
        return new CsvEnumerator(_filePath);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
