namespace Core.Models;

public class Pokedex
{
    public uint PokedexId { get; set; }
    public List<Specie> Pokemon { get; set; }
}