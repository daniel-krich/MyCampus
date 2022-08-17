using MyCampusData.Entities;
using MyCampusData.Enums;
using MyCampusUI.Models;

namespace MyCampusUI.Interfaces.Services
{
    public interface IAuthenticationStateService
    {
        bool IsAuthenticated { get; }
        Guid? SessionId { get; }

        /// <summary>
        /// Use with caution, the db context is already disposed.
        /// Using lazy loading will throw an exception.
        /// </summary>
        public UserEntity? DisposedUserEntity { get; set; }
        Task<CookieModel> CreateJwtSessionToken(string username, string password, bool remember);
    }
}