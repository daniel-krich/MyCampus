using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace MyCampusUI.Components
{
    public class RedirectTo : ComponentBase
    {
        [Parameter] public string? Route { get; set; }
        [Parameter] public bool Reload { get; set; }
#nullable disable
        [Inject] public NavigationManager NavManager { get; set; }
#nullable enable

        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender && Route != null)
            {
                NavManager.NavigateTo(Route, Reload);
            }
        }
    }
}