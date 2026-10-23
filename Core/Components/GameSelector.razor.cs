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

    private Generation? _selectedGeneration;
    private List<Generation> _generations = [];
    
    private VersionGroup? _selectedVersionGroup;
    private List<VersionGroup> _versionGroupsForGeneration = [];
    private bool displayVersionGroups = false;
    
    protected override async Task OnInitializedAsync()
    {
        _generations = await PokeApiService.GetAllGenerationsAsync();
    }
    
    private async Task _selectGeneration(int generationId)
    {
        _selectedGeneration = await PokeApiService.GetGenerationAsync(generationId);
        _versionGroupsForGeneration.Clear();
        foreach (var versionGroup in _selectedGeneration.version_groups)
        {
            var versionGroupToAdd = await PokeApiService.GetVersionGroupAsync(null, versionGroup.name);
            _versionGroupsForGeneration.Add(versionGroupToAdd);
        }
        displayVersionGroups = _versionGroupsForGeneration.Count > 0;
    }
    
    private async Task _selectVersionGroup(int generationId)
    {
        /*_selectedGeneration = await _gameDetailsService.GetGenerationAsync(generationId);
        _versionGroupsForGeneration.Clear();
        foreach (var versionGroup in _selectedGeneration.version_groups)
        {
            var versionGroupToAdd = await _gameDetailsService.GetVersionGroupAsync(null, versionGroup.name);
            _versionGroupsForGeneration.Add(versionGroupToAdd);
        }
        displayVersionGroups = _versionGroupsForGeneration.Count > 0;*/
    }
}
