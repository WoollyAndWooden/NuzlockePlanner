namespace Core.Models;

public class Area
{
    public int areaId { get; set; }
    public string areaName { get; set; }
    public List<Encounter> encounters { get; set; }
}