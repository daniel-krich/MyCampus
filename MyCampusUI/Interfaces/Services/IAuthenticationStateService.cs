using MyCampusData.Entities;
using MyCampusData.Enums;
using MyCampusData.Models;

namespace MyCampusUI.Interfaces.Services
{
    public interface IAuthenticationStateService
    {
        bool IsAuthenticated { get; }
        string? SessionId { get; }
        string? UserId { get; }
        UserPermissionsEnum? UserPermissions { get; }
        string? Username { get; }

        /// <summary>
        /// Use with caution, the db context is already disposed.
        /// Using lazy loading will throw an exception.
        /// </summary>
        public UserEntity? DisposedUserEntity { get; }
        Task<CookieModel> CreateJwtSessionToken(string username, string password, bool remember);
    }
}