namespace Core.Models.Dto;

public class PokeApiListCountDto<T>
{
    public int count { get; set; }
    public List<T> results { get; set; } = [];
}