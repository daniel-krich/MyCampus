using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using MyCampusData.Data;
using MyCampusData.Entities;
using MyCampusData.Enums;
using MyCampusUI.Consts;
using MyCampusUI.Models;
using MyCampusUI.Interfaces.Services;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using MyCampusUI.Exceptions;

namespace MyCampusUI.Services;

public class AuthenticationStateService : IAuthenticationStateService
{
    private readonly IHttpContextAccessor _httpcontext;
    private readonly IDbContextFactory<CampusContext> _campusContextFactory;
    private readonly ITokenService _tokenService;

    public bool IsAuthenticated { get => _httpcontext.HttpContext?.User.Identity?.IsAuthenticated ?? false; }
    public Guid? SessionId { get => _httpcontext.HttpContext?.Items["SessionId"] as Guid?; }

    public UserEntity? DisposedUserEntity {
        get => _httpcontext.HttpContext?.Items["DisposedUserEntity"] as UserEntity;
        set
        {
            if (_httpcontext.HttpContext != null)
                _httpcontext.HttpContext.Items["DisposedUserEntity"] = value;
        }
    }

    public AuthenticationStateService(IDbContextFactory<CampusContext> campusContextFactory, IHttpContextAccessor httpcontext, ITokenService tokenService)
    {
        _campusContextFactory = campusContextFactory;
        _httpcontext = httpcontext;
        _tokenService = tokenService;
    }

    public async Task<CookieModel> CreateJwtSessionToken(string username, string password, bool remember)
    {
        using (var dbContext = await _campusContextFactory.CreateDbContextAsync())
        {
            var user = await dbContext.Users.FirstOrDefaultAsync(x => x.Username == username);
            if (user != null)
            {
                var salt = user.PasswordSalt;
                using HMACSHA512 hmac = new HMACSHA512(salt);
                byte[] hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                if (user.PasswordHash.SequenceEqual(hash))
                {
                    if(user.Permissions == UserPermissionsEnum.WaitingApproval) throw new UnapprovedUserException();

                    SessionEntity session = new SessionEntity
                    {
                        UserId = user.Id,
                        ExpireAt = remember ? DateTime.Now.Add(CookiesConst.AccessCookieExpire) : DateTime.Now.Add(CookiesConst.AccessCookieExpireTemp)
                    };
                    dbContext.Sessions.Add(session);
                    await dbContext.SaveChangesAsync();
                    var accessToken = _tokenService.GenerateAccessToken(new List<Claim>
                    {
                        new Claim(ClaimTypes.Sid, session.Id.ToString())
                    }, session.ExpireAt);
                    return new CookieModel(accessToken, session.ExpireAt);
                }
            }
            throw new InvalidCredentialsException();
        }
    }
}
