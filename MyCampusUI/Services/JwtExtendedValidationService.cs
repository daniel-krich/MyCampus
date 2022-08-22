using Microsoft.AspNetCore.Authentication.JwtBearer;
using MyCampusData.Data;
using System.Security.Claims;
using MyCampusData.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MyCampusUI.Services;
using MyCampusUI.Consts;
using System.Text;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using MyCampusData.Enums;

namespace MyCampusUI.Services
{
    public class ConfigureJwtBearerOptions : IConfigureNamedOptions<JwtBearerOptions>
    {
        private readonly IDbContextFactory<CampusContext> _campusContextFactory;
        public ConfigureJwtBearerOptions(IDbContextFactory<CampusContext> campusContextFactory)
        {
            _campusContextFactory = campusContextFactory;
        }

        public void Configure(string name, JwtBearerOptions options)
        {
            options.Events = new JwtExtendedValidationService(_campusContextFactory);
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,

                ValidIssuer = CookiesConst.IssuerAndAudience,
                ValidAudience = CookiesConst.IssuerAndAudience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(CookiesConst.SecretTokenKey))
            };
        }

        public void Configure(JwtBearerOptions options)
        {
            Configure(string.Empty, options);
        }
    }

    public class JwtExtendedValidationService : JwtBearerEvents
    {
        private readonly IDbContextFactory<CampusContext> _campusContextFactory;
        public JwtExtendedValidationService(IDbContextFactory<CampusContext> campusContextFactory)
        {
            _campusContextFactory = campusContextFactory;
        }

        public override Task MessageReceived(MessageReceivedContext context)
        {
            if (context.Request.Cookies.ContainsKey(CookiesConst.AccessCookie))
            {
                context.Token = context.Request.Cookies[CookiesConst.AccessCookie];
            }

            return Task.CompletedTask;
        }

        public override Task AuthenticationFailed(AuthenticationFailedContext context)
        {
            ResetSessionCookies(context);
            return Task.CompletedTask;
        }

        public override async Task TokenValidated(TokenValidatedContext context)
        {
            var sessionIdClaim = context.Principal.FindFirstValue(ClaimTypes.Sid);
            
            if (sessionIdClaim != null)
            {
                if (context.HttpContext.Request.Path.Equals("/_blazor"))
                {
                    using (var dbContext = await _campusContextFactory.CreateDbContextAsync())
                    {
                        SessionEntity? session = await dbContext.Sessions.Include(x => x.User).FirstOrDefaultAsync(x => x.Id == new Guid(sessionIdClaim));
                        if (session != null && session.User != null)
                        {
                            if (session.ExpireAt > DateTime.Now && session.User.Permissions > UserPermissionsEnum.WaitingApproval)
                            {
                                context.HttpContext.Items["SessionId"] = session.Id;
                                context.HttpContext.Items["UserEntity"] = session.User;
                                context.Success();
                                return;
                            }
                            else
                            {
                                dbContext.Remove(session);
                                await dbContext.SaveChangesAsync();
                            }
                        }
                        ResetSessionCookies(context);
                        context.Fail("Session expired");
                    }
                }
            }
        }

        private void ResetSessionCookies(ResultContext<JwtBearerOptions> context)
        {
            CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.Expires = new DateTime(1970, 1, 1, 0, 0, 0);
            context.Response.Cookies.Append(CookiesConst.AccessCookie, "", cookieOptions);
        }
    }
}
