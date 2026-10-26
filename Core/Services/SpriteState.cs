using Core.Models;
using Microsoft.AspNetCore.Components;

namespace Core.Services;

public class SpriteState
{
    
    public event Action OnSpritesLoaded;

    private const string _basePath = "sprites/pokemon/";
    public List<(string name, string urlMain, string urlParty)> spritesForVersionGroup = [];
    public string OnErrorSprite = "sprites/pokemon/0.png";

    public string GetSprite(string name, bool isMain = true)
    {
        (string pokemonName, string main, string icon) = spritesForVersionGroup.FirstOrDefault(x => x.name == name);
        if (isMain)
            return main ?? OnErrorSprite;
        else
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
            var pokemon = await pokeApi.GetSpecieAsync(name: pokemonEntry.pokemon_species.name);
            string urlToAddMain = $"{_basePath}/";
            bool isShiny = Random.Shared.Next(8192) == 1;
            var (variant, icon, extension) = versionGroup.generation.name switch
            {
                "generation-i" => (versionGroup.name, isShiny) switch
                {
                    ("red-green-japan", false) => ($"versions/{versionGroup.generation.name}/{versionGroup.name}/", $"versions/{versionGroup.generation.name}/{versionGroup.name}/", ".png"),
                    ("red-green-japan", true) => ($"versions/{versionGroup.generation.name}/{versionGroup.name}/gray/", $"versions/{versionGroup.generation.name}/", ".png"),
                    ("red-blue" or "yellow", false) => ($"versions/{versionGroup.generation.name}/{versionGroup.name}/transparent/", $"versions/{versionGroup.generation.name}/{versionGroup.name}/transparent/", ".png"),
                    ("red-blue" or "yellow", true) => ($"versions/{versionGroup.generation.name}/{versionGroup.name}/transparen/gray/", $"versions/{versionGroup.generation.name}/{versionGroup.name}/transparent/", ".png"),
                },
                "generation-ii" => game.name switch
                {
                    "gold" or "silver" => ($"versions/{versionGroup.generation.name}/{game.name}/transparent/", $"versions/{versionGroup.generation.name}/{game.name}/transparent/", ".png"),
                    "crystal" => ($"versions/{versionGroup.generation.name}/{game.name}/animated/", $"versions/{versionGroup.generation.name}/{game.name}/transparent/", ".gif"),
                },
                "generation-iii" => game.name switch
                {
                    "emerald" => ($"versions/{versionGroup.generation.name}/{versionGroup.name}/animated/", $"versions/{versionGroup.generation.name}/icons/", ".png"),
                    _ => ($"versions/{versionGroup.generation.name}/{versionGroup.name}/", $"versions/{versionGroup.generation.name}/icons/", ".png"),
                },
                "generation-iv" => ($"versions/{versionGroup.generation.name}/{versionGroup.name}/animated/", $"versions/{versionGroup.generation.name}/icons/", ".png"),
                "generation-v" => ($"versions/{versionGroup.generation.name}/black-white/animated", $"versions/{versionGroup.generation.name}/icons/", ".gif"),
                "generation-vi" => ($"versions/{versionGroup.generation.name}/{versionGroup.name}/", $"versions/{versionGroup.generation.name}/icons/", ".png"),
                "generation-vii" => ($"other/official-artwork/", $"versions/{versionGroup.generation.name}/icons/", ".png"),
                "generation-viii" or "generation-ix" => ($"other/official-artwork/", $"versions/{versionGroup.generation.name}/{versionGroup.name}/icons/", ".png"),
            };
            
            // had to make not every gen to support shiny. Bummer.
            isShiny = versionGroup.generation.name switch
            {
                "generation-i" or "generation-ii" or "generation-vii" or "generation-viii" or "generation-ix" =>
                    isShiny = false,
            };
            string spriteMain = $"{urlToAddMain}{variant}" + ((isShiny) ? "shiny/" : "") + $"{pokemon.id}{extension}";
            string spriteIcon = $"{urlToAddMain}{icon}{pokemon.id}.png";

            spritesForVersionGroup.Add((pokemon.name, spriteMain, spriteIcon));
            OnSpritesLoaded?.Invoke();
        }
    }
}