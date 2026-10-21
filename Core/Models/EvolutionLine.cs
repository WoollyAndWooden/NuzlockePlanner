namespace Core.Models;

public class EvolutionLine
{
    public uint evolutionLineId { get; set; }
    public Specie baseForm { get; set; }
    public List<Specie> evolutions { get; set; }
}