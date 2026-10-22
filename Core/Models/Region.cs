namespace Core.Models;

public class Region
{
    public uint regionIdId { get; set; }
    public string name { get; set; }
    public List<Location> locations { get; set; }
}
