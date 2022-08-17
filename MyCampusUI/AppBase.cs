using Microsoft.AspNetCore.Components;
using MyCampusUI.Services;

namespace MyCampusUI;

public class AppBase : ComponentBase
{
    [Inject] protected CustomNavigationService? NavigationService { get; set; }

    public AppBase()
    {

    }
}
