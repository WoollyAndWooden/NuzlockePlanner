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
        [Inject]
        private SpriteState _spriteState { get; set; }
        
        private Pokedex? _pokedex { get; set; }
        
        private CancellationTokenSource _cts;

        protected override async Task OnInitializedAsync()
        {
            _gameSelectionState.OnChangeGame += OnGameChanged;
            _gameSelectionState.OnChangeVersionGroup += OnVersionGroupChanged;
            _spriteState.OnSpritesLoaded += OnSpritesLoaded;
            await LoadPokedexAsync();
        }

        private async void OnGameChanged()
        {
            _cts?.Cancel();
            _cts = new CancellationTokenSource();
            try
            {
                if (_gameSelectionState.SelectedGame is not null)
                    _spriteState.LoadSpriteData(_pokeApi, _pokedex, _gameSelectionState.SelectedVersionGroup,
                        _gameSelectionState.SelectedGame, _cts.Token);
            }
            catch (OperationCanceledException)
            {
                _spriteState.spritesForVersionGroup.Clear();
            }
        }

        private async void OnVersionGroupChanged()
        {
            _cts?.Cancel();
            _spriteState.spritesForVersionGroup.Clear();
            await LoadPokedexAsync();
        }

        private void OnSpritesLoaded()
        {
            StateHasChanged();
        }

        private async Task LoadPokedexAsync()
        {
            if (_gameSelectionState.SelectedVersionGroup is not null)
            {
                var temp = _gameSelectionState.SelectedVersionGroup.pokedexes?.FirstOrDefault();
                //_pokedex = (temp is not null) ? await _pokeApi.GetPokedexAsync(temp.id, temp.name) : null;
                
            }
            else
                _pokedex = null;
            StateHasChanged();
        }
        
        private async Task GetSpriteDataAsync(Specie? pokemon){}

        public void Dispose()
        {
            _gameSelectionState.OnChangeGame -= OnGameChanged;
            _gameSelectionState.OnChangeVersionGroup -= OnVersionGroupChanged;
            _spriteState.OnSpritesLoaded -= OnSpritesLoaded;
        }
    }
}
