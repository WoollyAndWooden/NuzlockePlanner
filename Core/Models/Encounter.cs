using PokeApiClientNS;

namespace Core.Models;

public class Encounter
{
    public int id { get; set; }
    public EncounterSlot encounterSlot { get; set; }
    public Specie pokemonSpecie { get; set; }
    public int minLevel { get; set; }
    public int maxLevel { get; set; }
    public int rarity { get; set; }

    public Encounter(IGetGameDataForVersion_EncountersData_Pokemon_v2_encounters encounter)
    {
        id = encounter.Id;
        minLevel = encounter.Min_level;
        maxLevel = encounter.Max_level;
        rarity = rarity;
        if(encounter.Pokemon_v2_encounterslot is not null)
            encounterSlot = new EncounterSlot(encounter.Pokemon_v2_encounterslot);
        
        pokemonSpecie = new Specie
        {
            id = encounter.Pokemon_v2_pokemon.Id,
            name = encounter.Pokemon_v2_pokemon.Name
        };
    }
}
