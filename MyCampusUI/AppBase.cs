using Microsoft.AspNetCore.Components;
using MyCampusUI.Interfaces.Services;
using MyCampusUI.Services;

namespace MyCampusUI;

public class AppBase : ComponentBase
{
    [Inject] protected ICustomNavigationService? NavigationService { get; set; }

    public AppBase()
    {

    }
}
