using NuzlockePlanner.Shared.Models;

namespace NuzlockePlanner.Shared.Services;

public class DataService
{
    public List<Generation> Generations { get; private set; } = new();
    public List<Pokemon> Pokemons { get; private set; } = new();

    public DataService()
    {
        InitializeData();
    }

    private void InitializeData()
    {
        // 1. Create Pokemon (Gen 1)
        Pokemons = new List<Pokemon>
        {
            new() { Id = 1, Name = "Bulbasaur", Type1 = PokemonType.Grass, Type2 = PokemonType.Poison },
            new() { Id = 2, Name = "Ivysaur", Type1 = PokemonType.Grass, Type2 = PokemonType.Poison },
            new() { Id = 3, Name = "Venusaur", Type1 = PokemonType.Grass, Type2 = PokemonType.Poison },
            new() { Id = 4, Name = "Charmander", Type1 = PokemonType.Fire },
            new() { Id = 5, Name = "Charmeleon", Type1 = PokemonType.Fire },
            new() { Id = 6, Name = "Charizard", Type1 = PokemonType.Fire, Type2 = PokemonType.Flying },
            new() { Id = 7, Name = "Squirtle", Type1 = PokemonType.Water },
            new() { Id = 8, Name = "Wartortle", Type1 = PokemonType.Water },
            new() { Id = 9, Name = "Blastoise", Type1 = PokemonType.Water },
            new() { Id = 10, Name = "Caterpie", Type1 = PokemonType.Bug },
            new() { Id = 11, Name = "Metapod", Type1 = PokemonType.Bug },
            new() { Id = 12, Name = "Butterfree", Type1 = PokemonType.Bug, Type2 = PokemonType.Flying },
            new() { Id = 13, Name = "Weedle", Type1 = PokemonType.Bug, Type2 = PokemonType.Poison },
            new() { Id = 14, Name = "Kakuna", Type1 = PokemonType.Bug, Type2 = PokemonType.Poison },
            new() { Id = 15, Name = "Beedrill", Type1 = PokemonType.Bug, Type2 = PokemonType.Poison },
            new() { Id = 16, Name = "Pidgey", Type1 = PokemonType.Normal, Type2 = PokemonType.Flying },
            new() { Id = 17, Name = "Pidgeotto", Type1 = PokemonType.Normal, Type2 = PokemonType.Flying },
            new() { Id = 18, Name = "Pidgeot", Type1 = PokemonType.Normal, Type2 = PokemonType.Flying },
            new() { Id = 19, Name = "Rattata", Type1 = PokemonType.Normal },
            new() { Id = 20, Name = "Raticate", Type1 = PokemonType.Normal },
            new() { Id = 21, Name = "Spearow", Type1 = PokemonType.Normal, Type2 = PokemonType.Flying },
            new() { Id = 22, Name = "Fearow", Type1 = PokemonType.Normal, Type2 = PokemonType.Flying },
            new() { Id = 23, Name = "Ekans", Type1 = PokemonType.Poison },
            new() { Id = 24, Name = "Arbok", Type1 = PokemonType.Poison },
            new() { Id = 25, Name = "Pikachu", Type1 = PokemonType.Electric },
            new() { Id = 26, Name = "Raichu", Type1 = PokemonType.Electric },
            new() { Id = 27, Name = "Sandshrew", Type1 = PokemonType.Ground },
            new() { Id = 28, Name = "Sandslash", Type1 = PokemonType.Ground },
            new() { Id = 29, Name = "Nidoran♀", Type1 = PokemonType.Poison },
            new() { Id = 30, Name = "Nidorina", Type1 = PokemonType.Poison },
            new() { Id = 31, Name = "Nidoqueen", Type1 = PokemonType.Poison, Type2 = PokemonType.Ground },
            new() { Id = 32, Name = "Nidoran♂", Type1 = PokemonType.Poison },
            new() { Id = 33, Name = "Nidorino", Type1 = PokemonType.Poison },
            new() { Id = 34, Name = "Nidoking", Type1 = PokemonType.Poison, Type2 = PokemonType.Ground },
            new() { Id = 35, Name = "Clefairy", Type1 = PokemonType.Fairy },
            new() { Id = 36, Name = "Clefable", Type1 = PokemonType.Fairy },
            new() { Id = 37, Name = "Vulpix", Type1 = PokemonType.Fire },
            new() { Id = 38, Name = "Ninetales", Type1 = PokemonType.Fire },
            new() { Id = 39, Name = "Jigglypuff", Type1 = PokemonType.Normal, Type2 = PokemonType.Fairy },
            new() { Id = 40, Name = "Wigglytuff", Type1 = PokemonType.Normal, Type2 = PokemonType.Fairy },
            new() { Id = 41, Name = "Zubat", Type1 = PokemonType.Poison, Type2 = PokemonType.Flying },
            new() { Id = 42, Name = "Golbat", Type1 = PokemonType.Poison, Type2 = PokemonType.Flying },
            new() { Id = 43, Name = "Oddish", Type1 = PokemonType.Grass, Type2 = PokemonType.Poison },
            new() { Id = 44, Name = "Gloom", Type1 = PokemonType.Grass, Type2 = PokemonType.Poison },
            new() { Id = 45, Name = "Vileplume", Type1 = PokemonType.Grass, Type2 = PokemonType.Poison },
            new() { Id = 46, Name = "Paras", Type1 = PokemonType.Bug, Type2 = PokemonType.Grass },
            new() { Id = 47, Name = "Parasect", Type1 = PokemonType.Bug, Type2 = PokemonType.Grass },
            new() { Id = 48, Name = "Venonat", Type1 = PokemonType.Bug, Type2 = PokemonType.Poison },
            new() { Id = 49, Name = "Venomoth", Type1 = PokemonType.Bug, Type2 = PokemonType.Poison },
            new() { Id = 50, Name = "Diglett", Type1 = PokemonType.Ground },
            new() { Id = 51, Name = "Dugtrio", Type1 = PokemonType.Ground },
            new() { Id = 52, Name = "Meowth", Type1 = PokemonType.Normal },
            new() { Id = 53, Name = "Persian", Type1 = PokemonType.Normal },
            new() { Id = 54, Name = "Psyduck", Type1 = PokemonType.Water },
            new() { Id = 55, Name = "Golduck", Type1 = PokemonType.Water },
            new() { Id = 56, Name = "Mankey", Type1 = PokemonType.Fighting },
            new() { Id = 57, Name = "Primeape", Type1 = PokemonType.Fighting },
            new() { Id = 58, Name = "Growlithe", Type1 = PokemonType.Fire },
            new() { Id = 59, Name = "Arcanine", Type1 = PokemonType.Fire },
            new() { Id = 60, Name = "Poliwag", Type1 = PokemonType.Water },
            new() { Id = 61, Name = "Poliwhirl", Type1 = PokemonType.Water },
            new() { Id = 62, Name = "Poliwrath", Type1 = PokemonType.Water, Type2 = PokemonType.Fighting },
            new() { Id = 63, Name = "Abra", Type1 = PokemonType.Psychic },
            new() { Id = 64, Name = "Kadabra", Type1 = PokemonType.Psychic },
            new() { Id = 65, Name = "Alakazam", Type1 = PokemonType.Psychic },
            new() { Id = 66, Name = "Machop", Type1 = PokemonType.Fighting },
            new() { Id = 67, Name = "Machoke", Type1 = PokemonType.Fighting },
            new() { Id = 68, Name = "Machamp", Type1 = PokemonType.Fighting },
            new() { Id = 69, Name = "Bellsprout", Type1 = PokemonType.Grass, Type2 = PokemonType.Poison },
            new() { Id = 70, Name = "Weepinbell", Type1 = PokemonType.Grass, Type2 = PokemonType.Poison },
            new() { Id = 71, Name = "Victreebel", Type1 = PokemonType.Grass, Type2 = PokemonType.Poison },
            new() { Id = 72, Name = "Tentacool", Type1 = PokemonType.Water, Type2 = PokemonType.Poison },
            new() { Id = 73, Name = "Tentacruel", Type1 = PokemonType.Water, Type2 = PokemonType.Poison },
            new() { Id = 74, Name = "Geodude", Type1 = PokemonType.Rock, Type2 = PokemonType.Ground },
            new() { Id = 75, Name = "Graveler", Type1 = PokemonType.Rock, Type2 = PokemonType.Ground },
            new() { Id = 76, Name = "Golem", Type1 = PokemonType.Rock, Type2 = PokemonType.Ground },
            new() { Id = 77, Name = "Ponyta", Type1 = PokemonType.Fire },
            new() { Id = 78, Name = "Rapidash", Type1 = PokemonType.Fire },
            new() { Id = 79, Name = "Slowpoke", Type1 = PokemonType.Water, Type2 = PokemonType.Psychic },
            new() { Id = 80, Name = "Slowbro", Type1 = PokemonType.Water, Type2 = PokemonType.Psychic },
            new() { Id = 81, Name = "Magnemite", Type1 = PokemonType.Electric, Type2 = PokemonType.Steel },
            new() { Id = 82, Name = "Magneton", Type1 = PokemonType.Electric, Type2 = PokemonType.Steel },
            new() { Id = 83, Name = "Farfetch'd", Type1 = PokemonType.Normal, Type2 = PokemonType.Flying },
            new() { Id = 84, Name = "Doduo", Type1 = PokemonType.Normal, Type2 = PokemonType.Flying },
            new() { Id = 85, Name = "Dodrio", Type1 = PokemonType.Normal, Type2 = PokemonType.Flying },
            new() { Id = 86, Name = "Seel", Type1 = PokemonType.Water },
            new() { Id = 87, Name = "Dewgong", Type1 = PokemonType.Water, Type2 = PokemonType.Ice },
            new() { Id = 88, Name = "Grimer", Type1 = PokemonType.Poison },
            new() { Id = 89, Name = "Muk", Type1 = PokemonType.Poison },
            new() { Id = 90, Name = "Shellder", Type1 = PokemonType.Water },
            new() { Id = 91, Name = "Cloyster", Type1 = PokemonType.Water, Type2 = PokemonType.Ice },
            new() { Id = 92, Name = "Gastly", Type1 = PokemonType.Ghost, Type2 = PokemonType.Poison },
            new() { Id = 93, Name = "Haunter", Type1 = PokemonType.Ghost, Type2 = PokemonType.Poison },
            new() { Id = 94, Name = "Gengar", Type1 = PokemonType.Ghost, Type2 = PokemonType.Poison },
            new() { Id = 95, Name = "Onix", Type1 = PokemonType.Rock, Type2 = PokemonType.Ground },
            new() { Id = 96, Name = "Drowzee", Type1 = PokemonType.Psychic },
            new() { Id = 97, Name = "Hypno", Type1 = PokemonType.Psychic },
            new() { Id = 98, Name = "Krabby", Type1 = PokemonType.Water },
            new() { Id = 99, Name = "Kingler", Type1 = PokemonType.Water },
            new() { Id = 100, Name = "Voltorb", Type1 = PokemonType.Electric },
            new() { Id = 101, Name = "Electrode", Type1 = PokemonType.Electric },
            new() { Id = 102, Name = "Exeggcute", Type1 = PokemonType.Grass, Type2 = PokemonType.Psychic },
            new() { Id = 103, Name = "Exeggutor", Type1 = PokemonType.Grass, Type2 = PokemonType.Psychic },
            new() { Id = 104, Name = "Cubone", Type1 = PokemonType.Ground },
            new() { Id = 105, Name = "Marowak", Type1 = PokemonType.Ground },
            new() { Id = 106, Name = "Hitmonlee", Type1 = PokemonType.Fighting },
            new() { Id = 107, Name = "Hitmonchan", Type1 = PokemonType.Fighting },
            new() { Id = 108, Name = "Lickitung", Type1 = PokemonType.Normal },
            new() { Id = 109, Name = "Koffing", Type1 = PokemonType.Poison },
            new() { Id = 110, Name = "Weezing", Type1 = PokemonType.Poison },
            new() { Id = 111, Name = "Rhyhorn", Type1 = PokemonType.Ground, Type2 = PokemonType.Rock },
            new() { Id = 112, Name = "Rhydon", Type1 = PokemonType.Ground, Type2 = PokemonType.Rock },
            new() { Id = 113, Name = "Chansey", Type1 = PokemonType.Normal },
            new() { Id = 114, Name = "Tangela", Type1 = PokemonType.Grass },
            new() { Id = 115, Name = "Kangaskhan", Type1 = PokemonType.Normal },
            new() { Id = 116, Name = "Horsea", Type1 = PokemonType.Water },
            new() { Id = 117, Name = "Seadra", Type1 = PokemonType.Water },
            new() { Id = 118, Name = "Goldeen", Type1 = PokemonType.Water },
            new() { Id = 119, Name = "Seaking", Type1 = PokemonType.Water },
            new() { Id = 120, Name = "Staryu", Type1 = PokemonType.Water },
            new() { Id = 121, Name = "Starmie", Type1 = PokemonType.Water, Type2 = PokemonType.Psychic },
            new() { Id = 122, Name = "Mr. Mime", Type1 = PokemonType.Psychic, Type2 = PokemonType.Fairy },
            new() { Id = 123, Name = "Scyther", Type1 = PokemonType.Bug, Type2 = PokemonType.Flying },
            new() { Id = 124, Name = "Jynx", Type1 = PokemonType.Ice, Type2 = PokemonType.Psychic },
            new() { Id = 125, Name = "Electabuzz", Type1 = PokemonType.Electric },
            new() { Id = 126, Name = "Magmar", Type1 = PokemonType.Fire },
            new() { Id = 127, Name = "Pinsir", Type1 = PokemonType.Bug },
            new() { Id = 128, Name = "Tauros", Type1 = PokemonType.Normal },
            new() { Id = 129, Name = "Magikarp", Type1 = PokemonType.Water },
            new() { Id = 130, Name = "Gyarados", Type1 = PokemonType.Water, Type2 = PokemonType.Flying },
            new() { Id = 131, Name = "Lapras", Type1 = PokemonType.Water, Type2 = PokemonType.Ice },
            new() { Id = 132, Name = "Ditto", Type1 = PokemonType.Normal },
            new() { Id = 133, Name = "Eevee", Type1 = PokemonType.Normal },
            new() { Id = 134, Name = "Vaporeon", Type1 = PokemonType.Water },
            new() { Id = 135, Name = "Jolteon", Type1 = PokemonType.Electric },
            new() { Id = 136, Name = "Flareon", Type1 = PokemonType.Fire },
            new() { Id = 137, Name = "Porygon", Type1 = PokemonType.Normal },
            new() { Id = 138, Name = "Omanyte", Type1 = PokemonType.Rock, Type2 = PokemonType.Water },
            new() { Id = 139, Name = "Omastar", Type1 = PokemonType.Rock, Type2 = PokemonType.Water },
            new() { Id = 140, Name = "Kabuto", Type1 = PokemonType.Rock, Type2 = PokemonType.Water },
            new() { Id = 141, Name = "Kabutops", Type1 = PokemonType.Rock, Type2 = PokemonType.Water },
            new() { Id = 142, Name = "Aerodactyl", Type1 = PokemonType.Rock, Type2 = PokemonType.Flying },
            new() { Id = 143, Name = "Snorlax", Type1 = PokemonType.Normal },
            new() { Id = 144, Name = "Articuno", Type1 = PokemonType.Ice, Type2 = PokemonType.Flying },
            new() { Id = 145, Name = "Zapdos", Type1 = PokemonType.Electric, Type2 = PokemonType.Flying },
            new() { Id = 146, Name = "Moltres", Type1 = PokemonType.Fire, Type2 = PokemonType.Flying },
            new() { Id = 147, Name = "Dratini", Type1 = PokemonType.Dragon },
            new() { Id = 148, Name = "Dragonair", Type1 = PokemonType.Dragon },
            new() { Id = 149, Name = "Dragonite", Type1 = PokemonType.Dragon, Type2 = PokemonType.Flying },
            new() { Id = 150, Name = "Mewtwo", Type1 = PokemonType.Psychic },
            new() { Id = 151, Name = "Mew", Type1 = PokemonType.Psychic }
        };

        // 2. Create Region (Kanto)
        var kanto = new Region { Id = 1, Name = "Kanto" };

        // 3. Create Locations for Kanto
        var locationNames = new List<string>
        {
            "Pallet Town", "Viridian City", "Viridian Forest", "Pewter City", "Mt. Moon",
            "Cerulean City", "Cerulean Cave", "Rock Tunnel", "Lavender Town", "Pokemon Tower",
            "Vermilion City", "Diglett's Cave", "Saffron City", "Fighting Dojo", "Silph Co",
            "Celadon City", "Rocket Hideout", "Safari Zone", "Fuchsia City", "Seafoam Islands",
            "Cinnabar Island", "Pokemon Mansion", "Power Plant", "Victory Road", "Indigo Plateau"
        };

        // Add Routes 1-25
        for (int i = 1; i <= 25; i++)
        {
            locationNames.Insert(i - 1, $"Route {i}");
        }

        // 4. Create Generation I
        var genI = new Generation
        {
            Id = 1,
            Name = "Generation I",
            GenDir = "GenI"
        };

        // 5. Create Games (Red, Blue, Yellow)
        var games = new List<Game>
        {
            new Game { Id = 1, Name = "Red", Generation = genI, GenerationId = genI.Id, Region = kanto, RegionId = kanto.Id },
            new Game { Id = 2, Name = "Blue", Generation = genI, GenerationId = genI.Id, Region = kanto, RegionId = kanto.Id },
            new Game { Id = 3, Name = "Yellow", SeperateDir = true, Generation = genI, GenerationId = genI.Id, Region = kanto, RegionId = kanto.Id }
        };

        foreach (var game in games)
        {
            genI.Games.Add(game);
        }
        
        Generations.Add(genI);
        
        foreach (var game in games)
        {
            // Create a fresh Kanto for this game
            var gameRegion = new Region { Id = kanto.Id + game.Id * 100, Name = "Kanto" }; // Hacky ID to be unique
            game.Region = gameRegion;
            game.RegionId = gameRegion.Id;

            int locId = 1;
            int encounterId = 1;

            foreach (var name in locationNames)
            {
                var location = new Location
                {
                    Id = locId + (game.Id * 1000), // Unique ID
                    Name = name,
                    Region = gameRegion,
                    RegionId = gameRegion.Id
                };

                // --- Pallet Town Encounters ---
                if (name == "Pallet Town")
                {
                    // Gift Starters
                    if (game.Name == "Red" || game.Name == "Blue")
                    {
                        AddEncounter(location, "Bulbasaur", EncounterType.Gift, 5, 5, ref encounterId);
                        AddEncounter(location, "Charmander", EncounterType.Gift, 5, 5, ref encounterId);
                        AddEncounter(location, "Squirtle", EncounterType.Gift, 5, 5, ref encounterId);
                    }
                    else if (game.Name == "Yellow")
                    {
                        AddEncounter(location, "Pikachu", EncounterType.Gift, 5, 5, ref encounterId);
                    }

                    // Old Rod (All Games) - Magikarp 100%
                    AddEncounter(location, "Magikarp", EncounterType.OldRod, 5, 5, ref encounterId, 100);

                    // Good Rod (All Games) - Poliwag 50%, Goldeen 50%
                    AddEncounter(location, "Poliwag", EncounterType.GoodRod, 10, 10, ref encounterId, 50);
                    AddEncounter(location, "Goldeen", EncounterType.GoodRod, 10, 10, ref encounterId, 50);

                    // Super Rod
                    if (game.Name == "Red" || game.Name == "Blue")
                    {
                        AddEncounter(location, "Poliwag", EncounterType.SuperRod, 50, 50, ref encounterId, 50);
                        AddEncounter(location, "Tentacool", EncounterType.SuperRod, 50, 50, ref encounterId, 50);
                    }
                    else if (game.Name == "Yellow")
                    {
                        AddEncounter(location, "Staryu", EncounterType.SuperRod, 5, 10, ref encounterId, 60);
                        AddEncounter(location, "Tentacool", EncounterType.SuperRod, 10, 20, ref encounterId, 40);
                    }
                }
                
                // --- Route 1 Encounters (Example) ---
                else if (name == "Route 1")
                {
                    AddEncounter(location, "Pidgey", EncounterType.TallGrass, 2, 5, ref encounterId, 50);
                    AddEncounter(location, "Rattata", EncounterType.TallGrass, 2, 4, ref encounterId, 50);
                }

                gameRegion.Locations.Add(location);
                locId++;
            }
        }
    }

    private void AddEncounter(Location location, string pokemonName, EncounterType type, int minLvl, int maxLvl, ref int encounterId, int? chance = null)
    {
        var pokemon = Pokemons.FirstOrDefault(p => p.Name == pokemonName);
        if (pokemon == null) return;

        location.Encounters.Add(new Encounter
        {
            Id = encounterId++,
            Location = location,
            LocationId = location.Id,
            Pokemon = pokemon,
            PokemonId = pokemon.Id,
            Method = type,
            MinLevel = minLvl,
            MaxLevel = maxLvl,
            ChancePercentage = chance
        });
    }
}
