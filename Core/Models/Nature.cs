namespace Core.Models;

public class Nature
{
    public uint natureId { get; set; }
    public string name { get; set; }
    public Stat decreased_stat { get; set; }
    public Stat increased_stat { get; set; }
}