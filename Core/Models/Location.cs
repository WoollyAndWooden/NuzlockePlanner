namespace Core.Models;

public class Location
{
    public uint locationId { get; set; }
    public string name { get; set; }
    public List<Area> locationAreas { get; set; }
}