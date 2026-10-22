namespace Core.Models;

public class Encounter
{
    public uint encounterIdId { get; set; }
    public EncounterMethod encounterMethod { get; set; }
    public Specie pokemonSpecie { get; set; }
    public uint minLevel { get; set; }
    public uint maxLevel { get; set; }
    public uint encounterRate { get; set; }
    public string? condition { get; set; }
}
