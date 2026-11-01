using PokeApiClientNS;

namespace Core.Models;

public class EncounterSlot
{
    public int id { get; set; }
    public int rarity { get; set; }
    public EncounterMethod encounterMethod { get; set; }

    public EncounterSlot(IGetGameDataForVersion_EncountersData_Pokemon_v2_encounters_Pokemon_v2_encounterslot slot)
    {
        id = slot.Id;
        rarity = slot.Rarity;
        encounterMethod = new EncounterMethod(slot.Pokemon_v2_encountermethod);
    }
}