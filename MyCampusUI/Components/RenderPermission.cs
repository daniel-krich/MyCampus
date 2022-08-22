using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using MyCampusData.Enums;
using MyCampusUI.Interfaces.Services;

namespace MyCampusUI.Components
{
    public class RenderPermission : ComponentBase
    {
#nullable disable
        [Parameter] public RenderFragment ChildContent { get; set; }
        [Parameter] public bool RedirectIfInvalid { get; set; }
        [Parameter] public string RedirectUrl { get; set; } = "/";
        [Parameter] public bool RedirectForce { get; set; }
        [Inject] public IAuthenticationStateService AuthenticationState { get; set; }
        [Inject] public ICustomNavigationService CustomNavigationService { get; set; }
#nullable enable

        [Parameter] public UserPermissionsEnum[]? Permissions { get; set; }
        [Parameter] public UserPermissionsEnum? Permission { get; set; }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            if ((Permissions != null && Permissions.Any(x => x == AuthenticationState.User?.Permissions)) || (Permission != null && Permission == AuthenticationState.User?.Permissions))
            {
                base.BuildRenderTree(builder);

                builder.OpenRegion(0);
                builder.AddContent(1, ChildContent);
                builder.CloseRegion();
            }
            else if(RedirectIfInvalid)
            {
                CustomNavigationService.NavigateTo(RedirectUrl, RedirectForce);
            }
        }
    }
}
