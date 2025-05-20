using CSV_Enumerable.Mappings;
using CSV_Enumerable.Models;
using CsvHelper;
using System.Collections;
using System.Globalization;
using System.Text;

namespace CSV_Enumerable.Services;

internal class CsvEnumerator : IEnumerator<Pet>
{
    private StreamReader _stream;
    private CsvReader _reader;
    private Pet? _current;

    public CsvEnumerator(string filePath)
    {
        _stream = new StreamReader(filePath);
        _reader = new CsvReader(_stream, CultureInfo.InvariantCulture);

        _reader.Context.RegisterClassMap<PetMap>();

        _reader.Read();
        _reader.ReadHeader();
    }

    public Pet Current 
    {
        get
        {
            if (_current == null || _stream == null || _reader == null)
            {
                throw new InvalidOperationException();
            }
            return _current;
        }
    }

    object? IEnumerator.Current => Current;

    public bool MoveNext()
    {
        if (!_reader.Read())
        {
            return false;
        }
        _current = _reader.GetRecord<Pet>();
        return true;
    }

    public void Reset()
    {
        _stream.DiscardBufferedData();
        _stream.BaseStream.Seek(0, SeekOrigin.Begin);
        _reader.ReadHeader();
        _reader.Read();
        _current = null;
    }

    public void Dispose()
    {
        _current = null;
        if (_reader != null )
        {
            _reader.Dispose();
        }
        if (_stream != null)
        {
            _stream.Close();
            _stream.Dispose();
        }
    }
}
