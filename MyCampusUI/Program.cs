using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MyCampusData.Data;
using MyCampusUI.Services;
using MyCampusUI.Interfaces.Services;
using MyCampusUI.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IAuthenticationStateService, AuthenticationStateService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<ICustomNavigationService, CustomNavigationService>();
builder.Services.AddDbContextFactory<CampusContext>(_ => { });

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

app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<AppendHostMiddleware>();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();