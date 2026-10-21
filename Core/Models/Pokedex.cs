namespace Core.Models;

public class Pokedex
{
    public uint pokedexId { get; set; }
    public List<Specie> pokemon { get; set; }
}