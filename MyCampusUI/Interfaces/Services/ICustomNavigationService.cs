namespace MyCampusUI.Interfaces.Services
{
    public interface ICustomNavigationService
    {
        string BaseUri { get; set; }
        string? CurrentPath { get; set; }
        string? PreviousPath { get; set; }

        void Dispose();
        void NavigatePreviousOrDefault(bool force = default);
        void NavigateTo(string path);
        void NavigateTo(string path, bool forceLoad = default);
        void ForceRefresh();
    }
}