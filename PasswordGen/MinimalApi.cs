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
                ApiUtente.MapGet("get", async (string username, string password, IUtenteService MangerU, IStringLocalizer<Program> localizer) =>
                {
                    return await MangerU.GetUtente(username, password) is Utente u
                           ? Results.Ok(u)
                           : Results.NotFound(localizer["userNotFound"].Value);
                });
                ApiUtente.MapPut("change", async (string username, string password, string? usernameNew, string? passwordNew, IUtenteService MangerU, IStringLocalizer<Program> localizer) =>
                {
                    return await MangerU.ChangeUtente(username, password, usernameNew, passwordNew) is true
                           ? Results.Ok(localizer["credentialChanged"].Value)
                           : Results.Problem(localizer["credentialNotChanged"].Value);
                });
                ApiUtente.MapDelete("delete", async (string username, string password, IUtenteService MangerU, IStringLocalizer<Program> localizer) =>
                {
                    return await MangerU.DeleteUtente(username, password) is true
                           ? Results.Ok(localizer["userDeleted"].Value)
                           : Results.BadRequest(localizer["userNotDeleted"].Value);
                });
                return app;
            }
            public static WebApplication AddEndPointPassword(this WebApplication app)
            {

                var ApiPassword = app.MapGroup("api/password");
          
                ApiPassword.MapPost("new", async (string username, string passwordUtente, string namePassword, string password, IPasswordService ManagerP, IStringLocalizer<Program> localizer) =>
                {

                    return await ManagerP.NewPassword(username, passwordUtente, namePassword, password) is true
                           ? Results.Ok(localizer["passwordCreated"].Value)
                           : Results.BadRequest(localizer["passwordNotCreated"].Value);
                });
            ApiPassword.MapPost("new/{type}", async (string username, string passwordUtente, string namePassword,TypePassword type, IPasswordService ManagerP, IStringLocalizer<Program> localizer) =>
            {

                return await ManagerP.NewPassword(username, passwordUtente, namePassword, type) is string s
                       ? Results.Ok(localizer["passwordCreated"].Value+":"+ s)
                       : Results.BadRequest(localizer["passwordNotCreated"].Value);
            });
            ApiPassword.MapGet("get", async (string username, string passwordUtente, string namePassword, IPasswordService ManagerP, IStringLocalizer<Program> localizer) =>
                {

                    return await ManagerP.GetPassword(username, passwordUtente, namePassword) is PasswordModel p
                           ? Results.Ok(p)
                           : Results.NotFound(localizer["passwordNotFound"].Value);
                });
                ApiPassword.MapGet("get/all", async (string username, string passwordUtente, IPasswordService ManagerP, IStringLocalizer<Program> localizer) =>
                {

                    return await ManagerP.GetPassword(username, passwordUtente) is List<PasswordModel> p
                          ? Results.Ok(p)
                          : Results.NotFound(localizer["userNotFound"].Value);
                });
                ApiPassword.MapPut("change", async (string username, string passwordUtente, string namePassword, string passwordNew, IPasswordService ManagerP, IStringLocalizer<Program> localizer) =>
                {

                    return await ManagerP.ChangePassword(username, passwordUtente, namePassword, passwordNew) is true
                           ? Results.Ok(localizer["passwordChanged"].Value)
                           : Results.BadRequest(localizer["passwordNotChanged"].Value);

                });
                ApiPassword.MapDelete("delete", async (string username, string passwordUtente, string namePassword, IPasswordService ManagerP, IStringLocalizer<Program> localizer) =>
                {

                    return await ManagerP.DeletePassword(username, passwordUtente, namePassword) is true
                           ? Results.Ok(localizer["passwordDeleted"].Value)
                           : Results.Problem(localizer["passwordNotDeleted"].Value);
                });
            return app;
            }
    }
}