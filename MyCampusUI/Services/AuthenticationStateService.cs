﻿using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using MyCampusData.Data;
using MyCampusData.Entities;
using MyCampusData.Models;
using MyCampusUI.Consts;
using MyCampusUI.Interfaces.Services;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace MyCampusUI.Services;

public class AuthenticationStateService : IAuthenticationStateService
{
    private readonly IHttpContextAccessor _httpcontext;
    private readonly IDbContextFactory<CampusContext> _campusContextFactory;
    private readonly ITokenService _tokenService;

    public bool IsAuthenticated { get => _httpcontext.HttpContext?.User.Identity?.IsAuthenticated ?? false; }
    public string? UserId { get => _httpcontext.HttpContext!.Items["UserId"]?.ToString(); }

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
                    try
                    {
                        SessionEntity session = new SessionEntity
                        {
                            User = user,
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
                    catch
                    {
                        return new CookieModel(false);
                    }
                }
            }
            return new CookieModel(false);
        }
    }
}
