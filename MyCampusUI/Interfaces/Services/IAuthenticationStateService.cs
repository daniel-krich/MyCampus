using MyCampusData.Entities;
using MyCampusData.Enums;
using MyCampusUI.Models;

namespace MyCampusUI.Interfaces.Services
{
    public interface IAuthenticationStateService
    {
        bool IsAuthenticated { get; }
        Guid? SessionId { get; }
        public UserEntity? User { get; set; }
        Task<CookieModel> CreateJwtSessionToken(string username, string password, bool remember);
    }
}