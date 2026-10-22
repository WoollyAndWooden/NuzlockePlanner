namespace Core.Models;

public class Location
{
    public uint locationIdId { get; set; }
    public string name { get; set; }
    public List<Area> locationAreas { get; set; }
}
