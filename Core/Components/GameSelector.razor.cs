using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Components;

namespace Core.Components;

public partial class GameSelector
{
    [Inject]
    private PokeApi _pokeApi { get; set; }
    [Inject]
    private GameSelectionState _gameSelectionState { get; set; }
    
    [Parameter]
    public EventCallback<int> OnGameSelected { get; set; }

    private bool _lockGeneration = false;
    private Generation? _selectedGeneration;
    private List<Generation> _generations = [];
    
    private bool _lockVersionGroups = false;
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
        _generations = await _pokeApi.GetAllGenerationsAsync();
    }
    
    private async Task _selectGeneration(int generationId)
    {
        _selectedGeneration = await _pokeApi.GetGenerationAsync(generationId);
        _clearVersionGroups();
        _clearGame();
        foreach (var versionGroup in _selectedGeneration?.version_groups!)
        {
            var versionGroupToAdd = await _pokeApi.GetVersionGroupAsync(null, versionGroup.name);
            if (versionGroupToAdd is not null)
                _versionGroupsForGeneration.Add(versionGroupToAdd);
        }
        _displayVersionGroups = _versionGroupsForGeneration.Count > 0;
    }
    
    private async Task _selectVersionGroup(int versionGroupId)
    {
        _gameSelectionState.SelectedVersionGroup = await _pokeApi.GetVersionGroupAsync(versionGroupId);
        _clearGame();
        foreach (var games in _gameSelectionState.SelectedVersionGroup?.versions!)
        {
            var gameToAdd = await _pokeApi.GetGameAsync(name: games.name);
            if (gameToAdd is not null)
                _games.Add(gameToAdd);
        }
        _displayGames = _games.Count > 1;

        if (_games.Count == 1)
        {
            await _selectGame(_games.First().id ?? 0);
        }
        
    }

    private void _clearVersionGroups()
    {
        _versionGroupsForGeneration.Clear();
        _displayVersionGroups = false;
        _gameSelectionState.SelectedVersionGroup = null;
    }

    private async Task _selectGame(int gameId)
    {
        _gameSelectionState.SelectedGame = await _pokeApi.GetGameAsync(gameId);
        _gameSelectionState.SelectedGame = _gameSelectionState.SelectedGame;
    }

    private void _clearGame()
    {
        _games.Clear();
        _displayGames = false;
        _gameSelectionState.SelectedGame = null;
    }
}
