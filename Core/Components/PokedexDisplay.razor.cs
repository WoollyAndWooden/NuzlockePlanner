using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Components;

namespace Core.Components
{

    public partial class PokedexDisplay : IDisposable
    {
        [Inject]
        private PokeApi _pokeApi { get; set; }
        [Inject]
        private GameSelectionState _gameSelectionState { get; set; }
        
        private Pokedex? _pokedex { get; set; }

        protected override async Task OnInitializedAsync()
        {
            _gameSelectionState.OnChangeGame += OnGameChanged;
            _gameSelectionState.OnChangeVersionGroup += OnVersionGroupChanged;
            await LoadPokedexAsync();
        }

        private async void OnGameChanged(){}
        private async void OnVersionGroupChanged() => await LoadPokedexAsync();

        private async Task LoadPokedexAsync()
        {
            if (_gameSelectionState.SelectedVersionGroup is not null)
            {
                var temp = _gameSelectionState.SelectedVersionGroup.pokedexes?.FirstOrDefault();
                _pokedex = (temp is not null) ? await _pokeApi.GetPokedexAsync(temp.id, temp.name) : null;
                
            }
            else
                _pokedex = null;
            StateHasChanged();
        }

        public void Dispose()
        {
            _gameSelectionState.OnChangeGame -= OnGameChanged;
            _gameSelectionState.OnChangeVersionGroup -= OnVersionGroupChanged;
        }
    }
}
