using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Components;

namespace Core.Components;

public partial class GameSelector
{
    [Inject]
    PokeApiService PokeApiService { get; set; }
    
    [Parameter]
    public EventCallback<int> OnGenerationSelected { get; set; }

    private bool _lockGeneration = false;
    private Generation? _selectedGeneration;
    private List<Generation> _generations = [];
    
    private bool _lockVersionGroups = false;
    private VersionGroup? _selectedVersionGroup;
    private readonly List<VersionGroup> _versionGroupsForGeneration = [];
    private bool _displayVersionGroups = false;

    public bool LockVersionGroups
    {
        get => _lockVersionGroups;
        set
        {
            _lockVersionGroups = value;
            if(_lockVersionGroups)
                _lockGeneration = value;
        }
    }

    private bool _lockGame = false;
    private bool _displayGames = false;
    private Game? _selectedGame;
    private List<Game> _games = [];

    public bool LockGame
    {
        get => _lockGame;
        set
        {
            _lockGame = value;
            if (_lockGame)
            {
                _lockGeneration = value;
                _lockVersionGroups = value;
            }
        }
    }
    
    protected override async Task OnInitializedAsync()
    {
        _generations = await PokeApiService.GetAllGenerationsAsync();
    }
    
    private async Task _selectGeneration(int generationId)
    {
        _selectedGeneration = await PokeApiService.GetGenerationAsync(generationId);
        _versionGroupsForGeneration.Clear();
        foreach (var versionGroup in _selectedGeneration?.version_groups!)
        {
            var versionGroupToAdd = await PokeApiService.GetVersionGroupAsync(null, versionGroup.name);
            if (versionGroupToAdd is not null)
                _versionGroupsForGeneration.Add(versionGroupToAdd);
        }
        _displayVersionGroups = _versionGroupsForGeneration.Count > 0;
    }
    
    private async Task _selectVersionGroup(int versionGroupId)
    {
        _selectedVersionGroup = await PokeApiService.GetVersionGroupAsync(versionGroupId);
        _games.Clear();
        foreach (var games in _selectedVersionGroup?.versions!)
        {
            var gameToAdd = await PokeApiService.GetGameAsync(name: games.name);
            if (gameToAdd is not null)
                _games.Add(gameToAdd);
        }
        _displayGames = _games.Count > 0;
    }

    private async Task _selectGame(int gameId)
    {
        _selectedGame = await PokeApiService.GetGameAsync(gameId);
    }
}
