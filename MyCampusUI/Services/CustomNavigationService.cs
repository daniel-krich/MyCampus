using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using MyCampusUI.Interfaces.Services;

namespace MyCampusUI.Services;

public class CustomNavigationService : IDisposable, ICustomNavigationService
{
    private readonly NavigationManager _navigationManager;
    public string? CurrentPath { get; set; }
    public string? PreviousPath { get; set; }
    public string BaseUri { get; set; }

    public CustomNavigationService(NavigationManager navigationManager)
    {
        _navigationManager = navigationManager;
        BaseUri = _navigationManager.BaseUri;
        CurrentPath = _navigationManager.Uri;
        _navigationManager.LocationChanged += OnLocationChanged;
    }

    private void OnLocationChanged(object? sender, LocationChangedEventArgs args)
    {
        PreviousPath = CurrentPath;
        CurrentPath = args.Location;
    }

    public void NavigatePreviousOrDefault(bool force = default)
    {
        _navigationManager.NavigateTo(PreviousPath ?? _navigationManager.BaseUri, force);
    }

    public void NavigateTo(string path)
    {
        _navigationManager.NavigateTo(path);
    }

    public void NavigateTo(string path, bool forceLoad = default)
    {
        _navigationManager.NavigateTo(path, forceLoad);
    }

    public void Dispose()
    {
        _navigationManager.LocationChanged -= OnLocationChanged;
    }
}
