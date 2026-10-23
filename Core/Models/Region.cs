namespace Core.Models;

public class Region : NameIdResource
{
    public List<Location> locations { get; set; }
}
