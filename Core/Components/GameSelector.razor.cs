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
}