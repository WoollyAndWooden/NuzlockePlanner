using Core.Models;
using Microsoft.AspNetCore.Components;

namespace Core.Services;

public class SpriteState
{
    
    public event Action OnSpritesLoaded;

    private const string _basePath = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/versions/";
    public List<(string name, string urlMain, string urlParty)> spritesForVersionGroup = [];
    public string OnErrorSprite = "https://github.com/PokeAPI/sprites/blob/master/sprites/pokemon/0.png?raw=true";

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
            string urlToAddMain = $"{_basePath}/{versionGroup.generation.name}/";
            bool isShiny = Random.Shared.Next(8192) == 1;
            var (variant, icon, extension) = versionGroup.generation.name switch
            {
                "generation-i" => (versionGroup.name, isShiny) switch
                {
                    ("red-green-japan", false) => ($"{versionGroup.name}/", $"{versionGroup.name}/", ".png"),
                    ("red-green-japan", true) => ($"{versionGroup.name}/gray/", "", ".png"),
                    ("red-blue" or "yellow", false) => ($"{versionGroup.name}/transparent/", $"{versionGroup.name}/transparent/", ".png"),
                    ("red-blue" or "yellow", true) => ($"{versionGroup.name}/transparen/gray/", $"{versionGroup.name}/transparent/", ".png"),
                },
                "generation-ii" => game.name switch
                {
                    "gold" or "silver" => ($"{game.name}/transparent/", $"{game.name}/transparent/", ".png"),
                    "crystal" => ($"{game.name}/animated/", $"{game.name}/transparent/", ".gif"),
                },
                "generation-iii" => game.name switch
                {
                    "emerald" => ($"{versionGroup.name}/animated/", "icons/", ".png"),
                    _ => ($"{versionGroup.name}/", "icons/", ".png"),
                },
                "generation-iv" => ($"{versionGroup.name}/animated/", "icons/", ".png"),
                "generation-v" => ("black-white/animated", "icons/", ".gif"),
                "generation-vi" => ($"{versionGroup.name}/", "icons/", ".png"),
                "generation-vii" => versionGroup.name switch
                {
                    "lets-go-pikachu-lets-go-eevee" => ($"{versionGroup.name}/", $"{versionGroup.name}/icons/", ".gif"),
                    _ => ("ultra-sun-ultra-moon/", "icons/", ".gif"),
                },
                "generation-viii" => versionGroup.name switch
                {
                    "brilliant-diamond-shining-pearl" => ("brilliant-diamond-shining-pearl/", "brilliant-diamond-shining-pearl/icons/", ".png"),
                    _ => ("sword-shield/", "sword-shield/icons/", ".webp"),
                },
                "generation-ix" => versionGroup.name switch
                {
                    "legends-za" => ("legends-za/", "legends-za/icons", ".png"),
                    _ => ("scarlet-violet/", "scarlet-violet/icons", ".webp"),
                },
            };
            string spriteMain = $"{urlToAddMain}{variant}" + ((isShiny) ? "shiny/" : "") + $"{pokemon.id}{extension}";
            string spriteIcon = $"{urlToAddMain}{icon}{pokemon.id}.png";

            spritesForVersionGroup.Add((pokemon.name, spriteMain, spriteIcon));
            OnSpritesLoaded?.Invoke();
        }
    }
}