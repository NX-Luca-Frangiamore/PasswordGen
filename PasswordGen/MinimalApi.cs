using PasswordGen.Service;
using PasswordGen;
using System.Runtime.CompilerServices;
using PasswordGen.Service.UtenteService;
using PasswordGen.Service.PasswordService;

namespace PasswordGen
{

    public static class AppRouteExtensions
    {
            public static WebApplication AddEndPointUtente(this WebApplication app)
            {
                var ApiUtente = app.MapGroup("api/utente");
                ApiUtente.MapPost("new", async (string username, string password, IUtenteService MangerU) =>
                {
                    return TypedResults.Ok(await MangerU.NewUtente(username, password));
                });
                ApiUtente.MapGet("get", async (string username, string password, IUtenteService MangerU) =>
                {
                    return TypedResults.Ok(await MangerU.GetUtente(username, password));
                });
                ApiUtente.MapPut("change", async (string username, string password, string usernameNew, string passwordNew, IUtenteService MangerU) =>
                {
                    return TypedResults.Ok(await MangerU.ChangeUtente(username, password, usernameNew, passwordNew));
                });
                ApiUtente.MapDelete("delete", async (string username, string password, IUtenteService MangerU) =>
                {
                    return TypedResults.Ok(await MangerU.DeleteUtente(username, password));
                });
                return app;
            }
            public static WebApplication AddEndPointPassword(this WebApplication app)
            {
                var ApiPassword = app.MapGroup("api/password");
                ApiPassword.MapPost("new", async (string username, string passwordUtente, string namePassword, string password, IPasswordService ManagerP) =>
                {

                    return TypedResults.Ok(await ManagerP.NewPassword(username, passwordUtente, namePassword, password));
                });
                ApiPassword.MapGet("get", async (string username, string passwordUtente, string namePassword, IPasswordService ManagerP) =>
                {

                    return TypedResults.Ok(await ManagerP.GetPassword(username, passwordUtente));
                });
                ApiPassword.MapGet("get/all", async (string username, string passwordUtente, IPasswordService ManagerP) =>
                {

                    return TypedResults.Ok(await ManagerP.GetPassword(username, passwordUtente));
                });
                ApiPassword.MapPut("change", async (string username, string passwordUtente, string namePassword, string passwordNew, IPasswordService ManagerP) =>
                {

                    return TypedResults.Ok(await ManagerP.ChangePassword(username, passwordUtente, namePassword, passwordNew));
                });
                ApiPassword.MapDelete("delete", async (string username, string passwordUtente, string namePassword, IPasswordService ManagerP) =>
                {

                    return TypedResults.Ok(await ManagerP.DeletePassword(username, passwordUtente, namePassword));
                });
            return app;
            }
    }
}