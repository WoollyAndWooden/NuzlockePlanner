using Microsoft.AspNetCore.Components;

namespace Core.Components
{

    public partial class Pokedex : ComponentBase
    {
        protected override void OnInitialized()
        {
            StateHasChanged();
        }
    }
}
