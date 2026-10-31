using PokeApiClientNS;

namespace Core.Models;

public class EncounterMethod : NameIdResource
{
    public int? order { get; set; }

    public EncounterMethod(
        IGetGameDataForVersion_EncountersData_Pokemon_v2_encounters_Pokemon_v2_encounterslot_Pokemon_v2_encountermethod
            encounterMethod)
    {
        id = encounterMethod.Id;
        name = encounterMethod.Name;
        order = encounterMethod.Order;
    }
}
