using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;
using MyCampusData.Data;
using MyCampusData.Entities;
using MyCampusUI.Consts;
using MyCampusUI.Extensions;
using MyCampusUI.Interfaces.Services;

namespace MyCampusUI.Components
{
    public class Logout : ComponentBase
    {
#nullable disable
        [Inject] public IAuthenticationStateService AuthService { get; set; }
        [Inject] public IDbContextFactory<CampusContext> DbContextFactory { get; set; }
        [Inject] public IJSRuntime JsRuntime { get; set; }
        [Inject] public NavigationManager NavManager { get; set; }
#nullable enable

        protected override async Task OnInitializedAsync()
        {
            if (AuthService?.IsAuthenticated == true && AuthService.SessionId != null)
            {
                using (var dbContext = await DbContextFactory.CreateDbContextAsync())
                {
                    try
                    {
                        dbContext.Sessions.Remove(new SessionEntity
                        {
                            Id = new Guid(AuthService.SessionId)
                        });
                        await dbContext.SaveChangesAsync();
                    }
                    catch { }
                    await JsRuntime.DeleteCookie(CookiesConst.AccessCookie);
                    NavManager.NavigateTo("/", true);
                }
            }
        }
    }
}