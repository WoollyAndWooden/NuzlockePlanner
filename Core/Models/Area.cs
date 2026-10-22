namespace Core.Models;

public class Area
{
    public uint areaIdId { get; set; }
    public string areaName { get; set; }
    public List<Encounter> encounters { get; set; }
}
