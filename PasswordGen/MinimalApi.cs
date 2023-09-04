using PasswordGen.Service.UtenteService;
using PasswordGen.Service.PasswordService;
using PasswordGen.Model;
using PasswordGen.Service.PasswordService.GeneratorePassword;
using static PasswordGen.Service.PasswordService.GeneratorePassword.Builder.Factory.FactoryBuilder;
using Microsoft.Extensions.Localization;

namespace PasswordGen
{

    public static class AppRouteExtensions
    {
            public static WebApplication AddEndPointUtente(this WebApplication app)
            {
            
                var ApiUtente = app.MapGroup("api/utente");
                ApiUtente.MapPost("new", async (string username, string password, IUtenteService MangerU, IStringLocalizer<Program> localizer) =>
                {
                    return await MangerU.NewUtente(username, password) is true
                           ? Results.Ok(localizer["userCreated"].Value)
                           : Results.BadRequest(localizer["userNotCreated"].Value);

                });
                ApiUtente.MapGet("get", async (string username, string password, IUtenteService MangerU, IStringLocalizer<Program> localizerus) =>
                {
                    return await MangerU.GetUtente(username, password) is Utente u
                           ? Results.Ok(u)
                           : Results.NotFound(localizerus["userNotFound"].Value);
                });
                ApiUtente.MapPut("change", async (string username, string password, string? usernameNew, string? passwordNew, IUtenteService MangerU, IStringLocalizer<Program> localizerus) =>
                {
                    return await MangerU.ChangeUtente(username, password, usernameNew, passwordNew) is true
                           ? Results.Ok(localizerus["credentialChanged"].Value)
                           : Results.Problem(localizerus["credentialNotChanged"].Value);
                });
                ApiUtente.MapDelete("delete", async (string username, string password, IUtenteService MangerU, IStringLocalizer<Program> localizerus) =>
                {
                    return await MangerU.DeleteUtente(username, password) is true
                           ? Results.Ok(localizerus["userDeleted"].Value)
                           : Results.BadRequest(localizerus["userNotDeleted"].Value);
                });
                return app;
            }
            public static WebApplication AddEndPointPassword(this WebApplication app)
            {

                var ApiPassword = app.MapGroup("api/password");
          
                ApiPassword.MapPost("new", async (string username, string passwordUtente, string namePassword, string password, IPasswordService ManagerP, IStringLocalizer<Program> localizerus) =>
                {

                    return await ManagerP.NewPassword(username, passwordUtente, namePassword, password) is true
                           ? Results.Ok(localizerus["passwordCreated"].Value)
                           : Results.BadRequest(localizerus["passwordNotCreated"].Value);
                });
            ApiPassword.MapPost("new/{type}", async (string username, string passwordUtente, string namePassword,TypePassword type, IPasswordService ManagerP, IStringLocalizer<Program> localizerus) =>
            {

                return await ManagerP.NewPassword(username, passwordUtente, namePassword, type) is string s
                       ? Results.Ok(localizerus["passwordCreated"].Value+":"+ s)
                       : Results.BadRequest(localizerus["passwordNotCreated"].Value);
            });
            ApiPassword.MapGet("get", async (string username, string passwordUtente, string namePassword, IPasswordService ManagerP, IStringLocalizer<Program> localizerus) =>
                {

                    return await ManagerP.GetPassword(username, passwordUtente, namePassword) is PasswordModel p
                           ? Results.Ok(p)
                           : Results.NotFound(localizerus["passwordNotFound"].Value);
                });
                ApiPassword.MapGet("get/all", async (string username, string passwordUtente, IPasswordService ManagerP, IStringLocalizer<Program> localizerus) =>
                {

                    return await ManagerP.GetPassword(username, passwordUtente) is List<PasswordModel> p
                          ? Results.Ok(p)
                          : Results.NotFound(localizerus["userNotFound"].Value);
                });
                ApiPassword.MapPut("change", async (string username, string passwordUtente, string namePassword, string passwordNew, IPasswordService ManagerP, IStringLocalizer<Program> localizerus) =>
                {

                    return await ManagerP.ChangePassword(username, passwordUtente, namePassword, passwordNew) is true
                           ? Results.Ok(localizerus["passwordChanged"].Value)
                           : Results.BadRequest(localizerus["passwordNotChanged"].Value);

                });
                ApiPassword.MapDelete("delete", async (string username, string passwordUtente, string namePassword, IPasswordService ManagerP, IStringLocalizer<Program> localizerus) =>
                {

                    return await ManagerP.DeletePassword(username, passwordUtente, namePassword) is true
                           ? Results.Ok(localizerus["passwordDeleted"].Value)
                           : Results.Problem(localizerus["passwordNotDeleted"].Value);
                });
            return app;
            }
    }
}