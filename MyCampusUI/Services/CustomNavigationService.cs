﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace MyCampusUI.Services;

public class CustomNavigationService : IDisposable
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

    public void NavigatePrevious()
    {
        _navigationManager.NavigateTo(PreviousPath ?? _navigationManager.BaseUri);
    }

    public void NavigateTo(string path)
    {
        _navigationManager.NavigateTo(path);
    }

    public void NavigateTo(string path, bool forceLoad = false)
    {
        _navigationManager.NavigateTo(path, forceLoad);
    }

    public void Dispose()
    {
        _navigationManager.LocationChanged -= OnLocationChanged;
    }
}
