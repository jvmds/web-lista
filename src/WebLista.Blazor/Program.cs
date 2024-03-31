using Keycloak.AuthServices.Authentication;
using Keycloak.AuthServices.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using WebLista.Blazor.Components;
using WebLista.CrossCutting.Dependencies;
using WebLista.Infrastructure.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddInfrastructure(builder.Configuration);
// builder.Services.AddKeycloakAuthentication(new KeycloakAuthenticationOptions()
// {
//                 AuthServerUrl = builder.Configuration["Keycloak:auth-server-url"]!,
//                 Realm = builder.Configuration["Keycloak:realm"]!,
//                 Resource = builder.Configuration["Keycloak:resource"]!,
//                 SslRequired = builder.Configuration["Keycloak:ssl-required"]!,
//                 VerifyTokenAudience = false,
// });
// builder.Services.AddKeycloakAuthorization(new KeycloakProtectionClientOptions()
// {
//                 AuthServerUrl = builder.Configuration["Keycloak:auth-server-url"]!,
//                 Realm = builder.Configuration["Keycloak:realm"]!,
//                 Resource = builder.Configuration["Keycloak:resource"]!,
//                 SslRequired = builder.Configuration["Keycloak:ssl-required"]!,
//                 VerifyTokenAudience = false,
// });
builder.Services.AddAuthentication(options =>
                {
                    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
                })
                .AddCookie(opt =>
                {
                    opt.ExpireTimeSpan = TimeSpan.FromMinutes(1);
                })
                .AddOpenIdConnect(options =>
                {
                    options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    options.Authority =
                                    $"{builder.Configuration["Keycloak:auth-server-url"]}realms/{builder.Configuration["Keycloak:realm"]}";
                    options.ClientId = builder.Configuration["Keycloak:resource"];
                    options.ResponseType = OpenIdConnectResponseType.CodeIdTokenToken;
                    options.UsePkce = true;
                    options.Scope.Add("profile");
                    options.SaveTokens = true;
                    options.GetClaimsFromUserInfoEndpoint = true;
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters() { RoleClaimType = "roles" };
                });

builder.Services.AddOidcAuthentication(options =>
{
    options.ProviderOptions.Authority = $"{builder.Configuration["Keycloak:auth-server-url"]}realms/{builder.Configuration["Keycloak:realm"]}";
    options.ProviderOptions.ClientId = builder.Configuration["Keycloak:resource"];
    options.ProviderOptions.MetadataUrl = $"{builder.Configuration["Keycloak:auth-server-url"]}realms/{builder.Configuration["Keycloak:realm"]}/.well-known/openid-configuration";
    options.ProviderOptions.ResponseType = "id_token token";
    options.UserOptions.RoleClaim = "roles";
    options.UserOptions.ScopeClaim = "scope";
});

builder.Services.AddCascadingAuthenticationState();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

//app.UseCors(a => a.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
