namespace Core.Models;

public class PokemonType
{
    public uint typeId { get; set; }
    public string typeName { get; set; }
    public List<PokemonType> superEffectiveTaken { get; set; }
    public List<PokemonType> superEffectiveDealt { get; set; }
    public List<PokemonType> notEffectiveTaken { get; set; }
    public List<PokemonType> notEffectiveDealt { get; set; }
    public List<PokemonType> immuneTaken { get; set; }
    public List<PokemonType> immuneDealt { get; set; }
}