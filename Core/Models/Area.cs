using PokeApiClientNS;

namespace Core.Models;

public class Area : NameIdResource
{
    public List<Encounter> encounters { get; set; }
    public Location location { get; set; }

    public Area(IGetGameDataForVersion_EncountersData area)
    {
        Id = area.Id;
        Name = area.Name;
        foreach(var encounter in area.Pokemon_v2_encounters)
            encounters.Add(new Encounter(encounter));
        location = new Location
        {
            Id = area.Id,
            Name = area.Name
        };
    }
}
