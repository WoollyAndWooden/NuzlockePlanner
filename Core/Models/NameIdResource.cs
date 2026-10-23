using System.Text.RegularExpressions;

namespace Core.Models;

public abstract class NameIdResource
{
    public int? id { get; set; }
    public string name { get; set; }

    public virtual void FullInitialization(NameIdResource data)
    {
        id = data.id;
    }
    
    public virtual string GetName()
    {
        return Regex.Replace(name.Replace('-', ' '), @"\b\w", m => m.Value.ToUpper());
    }
}