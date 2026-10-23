namespace Core.Models;

public abstract class NameIdResource
{
    public int? id { get; set; }
    public string name { get; set; }

    public virtual void FullInitialization(NameIdResource data)
    {
        id = data.id;
    }
}