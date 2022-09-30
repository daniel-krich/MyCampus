using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MyCampusData.Data;
using MyCampusUI.Services;
using MyCampusUI.Interfaces.Services;
using MyCampusUI.Middleware;
using Microsoft.AspNetCore.Authorization;
using NLog;
using NLog.Web;

var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Info("Application init.");

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Logging.ClearProviders();
    builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Warning);
    builder.Host.UseNLog();

    builder.Services.AddRazorPages();
    builder.Services.AddServerSideBlazor();
    builder.Services.AddHttpContextAccessor();
    builder.Services.AddScoped<IAuthenticationStateService, AuthenticationStateService>();
    builder.Services.AddScoped<ITokenService, TokenService>();
    builder.Services.AddScoped<ICustomNavigationService, CustomNavigationService>();
    builder.Services.AddScoped<IAssignmentManagerService, AssignmentManagerService>();
    builder.Services.AddScoped<IQuizManagerService, QuizManagerService>();
    builder.Services.AddScoped<ICourseManagerService, CourseManagerService>();
    builder.Services.AddDbContextFactory<CampusContext>();

    builder.Services.AddAuthentication(opt =>
    {
        opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
       .AddJwtBearer();
    builder.Services.AddSingleton<IConfigureOptions<JwtBearerOptions>, ConfigureJwtBearerOptions>();

    builder.Services.AddSingleton<IBundleFilesService, BundleFilesService>();

    builder.Services.AddAuthorization();

    var app = builder.Build();

    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Error");
        app.UseHsts();
    }

    //app.UseHttpsRedirection();

    app.UseStaticFiles();

    app.UseMiddleware<AppendHostMiddleware>();

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapBlazorHub();
    app.MapFallbackToPage("/_Host");

    app.Run();
}
catch (Exception exception)
{
    logger.Error(exception, "Application setup error.");
    throw;
}
finally
{
    LogManager.Shutdown();
}