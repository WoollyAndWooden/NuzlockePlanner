namespace Core.Models;

public class Location : NameIdResource
{
    public List<Area> locationAreas { get; set; }
}
