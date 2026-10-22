using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Components;

namespace Core.Components;

public partial class GameSelector
{
    [Inject]
    GameDetailsService _gameDetailsService { get; set; }

    private Generation? _selectedGeneration = null;
    private List<Generation> _generations = []; 
    
    protected override async Task OnInitializedAsync()
    {
        _generations = await _gameDetailsService.GetAllGenerationsAsync();
    }
}using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Components;

namespace Core.Components;

public partial class GameSelector
{
    [Parameter]
    public List<Generation> generations { get; set; } = new();

    [Parameter]
    public EventCallback<int> OnGenerationSelected { get; set; }

    [Inject]
    private GameDetailsService gameDetailsService { get; set; } = null!;

    private Generation? selectedGeneration = null;

    protected override async Task OnInitializedAsync()
    {
        generations = await gameDetailsService.GetAllGenerationsAsync();
    }

    private async Task SelectGeneration(int generationId)
    {
        selectedGeneration = await gameDetailsService.GetGenerationAsync(generationId);
        await OnGenerationSelected.InvokeAsync(generationId);
    }
}
