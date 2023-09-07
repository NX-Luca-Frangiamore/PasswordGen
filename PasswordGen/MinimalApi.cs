using PasswordGen.Service.UtenteService;
using PasswordGen.Service.PasswordService;
using PasswordGen.Model;
using PasswordGen.Service.PasswordService.GeneratorePassword;
using Microsoft.Extensions.Localization;
using PasswordGen.Service.Autenticazione;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using static PasswordGen.Service.PasswordService.GeneratorePassword.Factory.FactoryBuilder;


namespace PasswordGen
{
    static class Extentions
    {
        public static string? Get(this ClaimsPrincipal claims, string name)
        {
            return claims?.Claims?.FirstOrDefault(x => x.Type == name)?.Value;
        }
        public static int? GetInt(this string? s)
        {
            try
            {
                return int.Parse(s);
            }catch { return null; }
        }
    }
    public static class AppRouteExtensions
    {
        public static WebApplication AddEndPointUtente(this WebApplication app)
        {
            app.MapPost("login", async (string username, string password, Authentication au, IUtenteService MangerU, IStringLocalizer<Program> localizer) =>
            {
                return (await au.Login(username, password)) is string token
                        ? Results.Ok(token)
                        : Results.NotFound();

            });
            app.MapPost("api/utente/new", async (string username, string password, IUtenteService MangerU, IStringLocalizer<Program> localizer) =>
            {
                return await MangerU.NewUtente(username, password) is true
                       ? Results.Ok(localizer["userCreated"].Value)
                       : Results.BadRequest(localizer["userNotCreated"].Value);

            });

            var ApiUtente = app.MapGroup("api/utente").RequireAuthorization("user"); ;
            ApiUtente.MapGet("get", async (ClaimsPrincipal claims, IUtenteService MangerU, IStringLocalizer<Program> localizerus) =>
            {
                return await MangerU.GetUtente(claims.Get("id").GetInt()) is Utente u
                       ? Results.Ok(u)
                       : Results.NotFound(localizerus["userNotFound"].Value);
            });

            ApiUtente.MapPut("change", async (ClaimsPrincipal claims, string? usernameNew, string? passwordNew, IUtenteService MangerU, IStringLocalizer<Program> localizerus) =>
                {
                    return await MangerU.ChangeUtente(claims.Get("id").GetInt(), usernameNew, passwordNew) is true
                           ? Results.Ok(localizerus["credentialChanged"].Value)
                           : Results.Problem(localizerus["credentialNotChanged"].Value);
                });
            ApiUtente.MapDelete("delete", async (ClaimsPrincipal claims, IUtenteService MangerU, IStringLocalizer<Program> localizerus) =>
                {
                    return await MangerU.DeleteUtente(claims.Get("id").GetInt()) is true
                           ? Results.Ok(localizerus["userDeleted"].Value)
                           : Results.BadRequest(localizerus["userNotDeleted"].Value);
                });
            return app;
        }

        public static WebApplication AddEndPointPassword(this WebApplication app)
        {

            var ApiPassword = app.MapGroup("api/password").RequireAuthorization("user");

            ApiPassword.MapPost("new", async (ClaimsPrincipal claims, string namePassword, string password, IPasswordService ManagerP, IStringLocalizer<Program> localizerus) =>
            {
                return await ManagerP.NewPassword(claims.Get("id").GetInt(), namePassword, password) is true
                       ? Results.Ok(localizerus["passwordCreated"].Value)
                       : Results.BadRequest(localizerus["passwordNotCreated"].Value);
            }).RequireAuthorization("user");

            ApiPassword.MapPost("new/{type}", async (ClaimsPrincipal claims, string namePassword, TypePassword type, IPasswordService ManagerP, IStringLocalizer<Program> localizerus) =>
            {
                return await ManagerP.NewPasswordRandom(claims.Get("id").GetInt(), namePassword, type) is string s
                       ? Results.Ok(localizerus["passwordCreated"].Value + ":" + s)
                       : Results.BadRequest(localizerus["passwordNotCreated"].Value);
            });
            ApiPassword.MapGet("get", async (ClaimsPrincipal claims, string namePassword, IPasswordService ManagerP, IStringLocalizer<Program> localizerus) =>
                {

                    return await ManagerP.GetPassword(claims.Get("id").GetInt(), namePassword) is PasswordModel p
                           ? Results.Ok(p)
                           : Results.NotFound(localizerus["passwordNotFound"].Value);
                });
            ApiPassword.MapGet("get/all", async (ClaimsPrincipal claims, IPasswordService ManagerP, IStringLocalizer<Program> localizerus) =>
            {

                return await ManagerP.GetPassword(claims.Get("id").GetInt()) is List<PasswordModel> p
                      ? Results.Ok(p)
                      : Results.NotFound(localizerus["userNotFound"].Value);
            });
            ApiPassword.MapPut("change", async (ClaimsPrincipal claims, string namePassword, string passwordNew, IPasswordService ManagerP, IStringLocalizer<Program> localizerus) =>
            {

                return await ManagerP.ChangePassword(claims.Get("id").GetInt(), namePassword, passwordNew) is true
                       ? Results.Ok(localizerus["passwordChanged"].Value)
                       : Results.BadRequest(localizerus["passwordNotChanged"].Value);

            });
            ApiPassword.MapDelete("delete", async (ClaimsPrincipal claims, string namePassword, IPasswordService ManagerP, IStringLocalizer<Program> localizerus) =>
            {

                return await ManagerP.DeletePassword(claims.Get("id").GetInt(), namePassword) is true
                       ? Results.Ok(localizerus["passwordDeleted"].Value)
                       : Results.Problem(localizerus["passwordNotDeleted"].Value);
            });
            return app;
        }
    }
}