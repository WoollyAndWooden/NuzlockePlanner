using System.Text.RegularExpressions;

namespace Core.Models;

public abstract class NameIdResource
{
    public int? Id { get; set; }
    public string Name { get; set; }

    public virtual void FullInitialization(NameIdResource data)
    {
        Id = data.Id;
    }
    
    public virtual string GetName()
    {
        return Regex.Replace(Name.Replace('-', ' '), @"\b\w", m => m.Value.ToUpper());
    }
}