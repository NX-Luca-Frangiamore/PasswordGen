using PasswordGen.Service.UtenteService;
using PasswordGen.Service.PasswordService;
using PasswordGen.Model;
using PasswordGen.Service.PasswordService.GeneratorePassword;
using static PasswordGen.Service.PasswordService.GeneratorePassword.Builder.Factory.FactoryBuilder;

namespace PasswordGen
{

    public static class AppRouteExtensions
    {
            public static WebApplication AddEndPointUtente(this WebApplication app)
            {
                var ApiUtente = app.MapGroup("api/utente");
                ApiUtente.MapPost("new", async (string username, string password, IUtenteService MangerU) =>
                {
                    return await MangerU.NewUtente(username, password) is true
                           ? Results.Ok("utente creato")
                           : Results.BadRequest("utente non creato");

                });
                ApiUtente.MapGet("get", async (string username, string password, IUtenteService MangerU) =>
                {
                    return await MangerU.GetUtente(username, password) is Utente u
                           ? Results.Ok(u)
                           : Results.NotFound("utente non trovato");
                });
                ApiUtente.MapPut("change", async (string username, string password, string? usernameNew, string? passwordNew, IUtenteService MangerU) =>
                {
                    return await MangerU.ChangeUtente(username, password, usernameNew, passwordNew) is true
                           ? Results.Ok("credenziali cambiate")
                           : Results.Problem("credenziali non cambiate");
                });
                ApiUtente.MapDelete("delete", async (string username, string password, IUtenteService MangerU) =>
                {
                    return await MangerU.DeleteUtente(username, password) is true
                           ? Results.Ok("utente cancellato")
                           : Results.BadRequest("utente non cancellato");
                });
                return app;
            }
            public static WebApplication AddEndPointPassword(this WebApplication app)
            {

                var ApiPassword = app.MapGroup("api/password");
          
                ApiPassword.MapPost("new", async (string username, string passwordUtente, string namePassword, string password, IPasswordService ManagerP) =>
                {

                    return await ManagerP.NewPassword(username, passwordUtente, namePassword, password) is true
                           ? Results.Ok("password creata")
                           : Results.BadRequest("password non creata");
                });
            ApiPassword.MapPost("new/{type}", async (string username, string passwordUtente, string namePassword,TypePassword type, IPasswordService ManagerP) =>
            {

                return await ManagerP.NewPassword(username, passwordUtente, namePassword, type) is string s
                       ? Results.Ok("password creata:"+s)
                       : Results.BadRequest("password non creata");
            });
            ApiPassword.MapGet("get", async (string username, string passwordUtente, string namePassword, IPasswordService ManagerP) =>
                {

                    return await ManagerP.GetPassword(username, passwordUtente, namePassword) is PasswordModel p
                           ? Results.Ok(p)
                           : Results.NotFound("password non trovata");
                });
                ApiPassword.MapGet("get/all", async (string username, string passwordUtente, IPasswordService ManagerP) =>
                {

                    return await ManagerP.GetPassword(username, passwordUtente) is List<PasswordModel> p
                          ? Results.Ok(p)
                          : Results.NotFound("utente non trovato");
                });
                ApiPassword.MapPut("change", async (string username, string passwordUtente, string namePassword, string passwordNew, IPasswordService ManagerP) =>
                {

                    return await ManagerP.ChangePassword(username, passwordUtente, namePassword, passwordNew) is true
                           ? Results.Ok("password cambiata")
                           : Results.BadRequest("password non cambiata");

                });
                ApiPassword.MapDelete("delete", async (string username, string passwordUtente, string namePassword, IPasswordService ManagerP) =>
                {

                    return await ManagerP.DeletePassword(username, passwordUtente, namePassword) is true
                           ? Results.Ok("password cancellata")
                           : Results.Problem("password non cancellata");
                });
            return app;
            }
    }
}