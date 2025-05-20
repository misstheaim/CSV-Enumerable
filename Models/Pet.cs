namespace CSV_Enumerable.Models;

internal record class Pet
{ 
    public int Id { get; set; }

    public string? Name { get; set; }

    public Species Species { get; set; }

    public int OwnerId { get; set; }

    public Person? Owner { get; set; }
}
