namespace Core.Models;

public class Pokemon
{
    public uint pokemonId  { get; set; }
    public string? nickname { get; set; }
    public Ability? ownedAbility { get; set; }
    //public Item? heldItems { get; set; }
    public Game? gameCaught { get; set; }
    public string sprite  { get; set; }
    public Specie specie { get; set; }
    public List<Stat> currentStats { get; set; }
    public Nature? nature { get; set; }
    public uint level { get; set; }
    
}