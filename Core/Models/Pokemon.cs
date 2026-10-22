namespace Core.Models;

public class Pokemon
{
    public uint PokemonId  { get; set; }
    public string? Nickname { get; set; }
    public Ability? OwnedAbility { get; set; }
    //public Item? heldItems { get; set; }
    public Game? GameCaught { get; set; }
    public Specie Specie { get; set; }
    public Dictionary<Stat, uint> CurrentStats =  new Dictionary<Stat, uint>();

    public Nature? Nature { get; set; }
    public uint Level { get; set; }
    
}