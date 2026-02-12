using Microsoft.AspNetCore.Components;
using NuzlockePlanner.Shared.Models;
using NuzlockePlanner.Shared.Services;

namespace NuzlockePlanner.Shared.Pages;

public partial class Home
{
    [Inject]
    public DataService DataService { get; set; } = null!;

    private Generation? selectedGeneration;
    private Game? selectedGame;
    private Location? selectedLocation;

    protected override void OnInitialized()
    {
        // Default to first generation and first game
        selectedGeneration = DataService.Generations.FirstOrDefault();
        selectedGame = selectedGeneration?.Games.FirstOrDefault();
    }

    private void OnGenerationChanged(ChangeEventArgs e)
    {
        if (int.TryParse(e.Value?.ToString(), out int genId))
        {
            selectedGeneration = DataService.Generations.FirstOrDefault(g => g.Id == genId);
            selectedGame = selectedGeneration?.Games.FirstOrDefault();
            selectedLocation = null; // Reset selection
        }
    }

    private void OnGameChanged(int gameId)
    {
        selectedGame = selectedGeneration?.Games.FirstOrDefault(g => g.Id == gameId);
        selectedLocation = null; // Reset selection
    }

    private void SelectLocation(Location location)
    {
        selectedLocation = location;
    }

    private string GetMapPath()
    {
        if (selectedGeneration == null || selectedGame == null) return string.Empty;
        // Path format: _content/NuzlockePlanner.Shared/{GenDir}/{RegionName}.JPG
        // Note: Region name might need sanitization if it has spaces, but "Kanto" is fine.
        return $"_content/NuzlockePlanner.Shared/{selectedGeneration.GenDir}/{selectedGame.Region.Name}.JPG";
    }
}
