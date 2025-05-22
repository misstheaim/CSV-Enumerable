using CSV_Enumerable.Attributes;
using CSV_Enumerable.Mappings;

namespace CSV_Enumerable.Models;

[CsvMap(typeof(PetMap))]
internal record class Pet
{ 
    public int Id { get; set; }

    public string? Name { get; set; }

    public Species Species { get; set; }

    public int OwnerId { get; set; }

    public Person? Owner { get; set; }
}
