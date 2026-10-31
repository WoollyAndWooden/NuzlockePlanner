using Core.Models;
using Microsoft.AspNetCore.Components;

namespace Core.Services;

public class SpriteState
{
    
    public event Action OnSpritesLoaded;

    private const string _basePath = "sprites/pokemon/";
    public List<(string name, string urlMain, string urlParty)> spritesForVersionGroup = [];
    public string OnErrorSprite = "sprites/pokemon/0.png";

    public string GetSprite(string? name, bool isMain = true)
    {
        (string pokemonName, string main, string icon) = spritesForVersionGroup.FirstOrDefault(x => x.name == name);
        if (isMain)
            return main ?? OnErrorSprite;
        return icon ?? OnErrorSprite;
    }
    
    public async Task LoadSpriteData(
        PokeApi pokeApi, 
        Pokedex pokedex, VersionGroup versionGroup, Game game, 
        CancellationToken cancellationToken = default)
    {
        spritesForVersionGroup.Clear();
        foreach (var pokemonEntry in pokedex.pokemon_entries)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var pokemon = await pokeApi.GetSpecieAsync(name: pokemonEntry.pokemon_species.Name);
            string urlToAddMain = $"{_basePath}/";
            bool isShiny = Random.Shared.Next(8192) == 1;
            var (variant, icon, extension) = versionGroup.generation.Name switch
            {
                "generation-i" => (name: versionGroup.Name, isShiny) switch
                {
                    ("red-green-japan", false) => ($"versions/{versionGroup.generation.Name}/{versionGroup.Name}/", $"versions/{versionGroup.generation.Name}/{versionGroup.Name}/", ".png"),
                    ("red-green-japan", true) => ($"versions/{versionGroup.generation.Name}/{versionGroup.Name}/gray/", $"versions/{versionGroup.generation.Name}/", ".png"),
                    ("red-blue" or "yellow", false) => ($"versions/{versionGroup.generation.Name}/{versionGroup.Name}/transparent/", $"versions/{versionGroup.generation.Name}/{versionGroup.Name}/transparent/", ".png"),
                    ("red-blue" or "yellow", true) => ($"versions/{versionGroup.generation.Name}/{versionGroup.Name}/transparen/gray/", $"versions/{versionGroup.generation.Name}/{versionGroup.Name}/transparent/", ".png"),
                },
                "generation-ii" => game.Name switch
                {
                    "gold" or "silver" => ($"versions/{versionGroup.generation.Name}/{game.Name}/transparent/", $"versions/{versionGroup.generation.Name}/{game.Name}/transparent/", ".png"),
                    "crystal" => ($"versions/{versionGroup.generation.Name}/{game.Name}/animated/", $"versions/{versionGroup.generation.Name}/{game.Name}/transparent/", ".gif"),
                },
                "generation-iii" => game.Name switch
                {
                    "emerald" => ($"versions/{versionGroup.generation.Name}/{versionGroup.Name}/animated/", $"versions/{versionGroup.generation.Name}/icons/", ".png"),
                    _ => ($"versions/{versionGroup.generation.Name}/{versionGroup.Name}/", $"versions/{versionGroup.generation.Name}/icons/", ".png"),
                },
                "generation-iv" => ($"versions/{versionGroup.generation.Name}/{versionGroup.Name}/animated/", $"versions/{versionGroup.generation.Name}/icons/", ".png"),
                "generation-v" => ($"versions/{versionGroup.generation.Name}/black-white/animated", $"versions/{versionGroup.generation.Name}/icons/", ".gif"),
                "generation-vi" => ($"versions/{versionGroup.generation.Name}/{versionGroup.Name}/", $"versions/{versionGroup.generation.Name}/icons/", ".png"),
                "generation-vii" => ($"other/official-artwork/", $"versions/{versionGroup.generation.Name}/icons/", ".png"),
                "generation-viii" or "generation-ix" => ($"other/official-artwork/", $"versions/{versionGroup.generation.Name}/{versionGroup.Name}/icons/", ".png"),
            };
            
            // had to make not every gen to support shiny. Bummer.
            isShiny = versionGroup.generation.Name switch
            {
                "generation-i" or "generation-ii" or "generation-vii" or "generation-viii" or "generation-ix" =>
                    isShiny = false,
            };
            string spriteMain = $"{urlToAddMain}{variant}" + ((isShiny) ? "shiny/" : "") + $"{pokemon.Id}{extension}";
            string spriteIcon = $"{urlToAddMain}{icon}{pokemon.Id}.png";

            spritesForVersionGroup.Add((pokemon.Name, spriteMain, spriteIcon));
            OnSpritesLoaded?.Invoke();
        }
    }
}