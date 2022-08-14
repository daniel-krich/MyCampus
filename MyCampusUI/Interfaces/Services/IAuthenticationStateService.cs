using MyCampusData.Enums;
using MyCampusData.Models;

namespace MyCampusUI.Interfaces.Services
{
    public interface IAuthenticationStateService
    {
        bool IsAuthenticated { get; }
        string? UserId { get; }
        UserPermissionsEnum? UserPermissions { get; }
        string? Username { get; }
        Task<CookieModel> CreateJwtSessionToken(string username, string password, bool remember);
    }
}