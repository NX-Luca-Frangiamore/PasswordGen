using PasswordGen.Service;
using PasswordGen.Model;
using System.Runtime.CompilerServices;
using PasswordGen.Service.Db;
using PasswordGen.Service.Business.BusinessUtente;
using PasswordGen.Service.Business.BusinessPassword;

namespace PasswordGen
{

    
    public static class AppRouteExtensions
    {
            public static WebApplication AddEndPointUtente(this WebApplication app)
            {
                app.MapPost("/api/new/utente", async (string username, string password, IManagerUtente MangerU) =>
                {
                    return TypedResults.Ok(MangerU.NewUtente(username, password));
                });
                app.MapGet("/api/get/utente", async (string username, string password, IManagerUtente MangerU) =>
                {
                    return TypedResults.Ok(MangerU.GetUtente(username, password));
                });
                app.MapPut("/api/change/utente", async (string username, string password, string usernameNew, string passwordNew, IManagerUtente MangerU) =>
                {
                    return TypedResults.Ok(MangerU.ChangeUtente(username, password, usernameNew, passwordNew));
                });
                app.MapPut("/api/delete/utente", async (string username, string password, IManagerUtente MangerU) =>
                {
                    return TypedResults.Ok(MangerU.DeleteUtente(username, password));
                });
                return app;
            }
            public static WebApplication AddEndPointPassword(this WebApplication app)
            {
                app.MapPost("/api/new/password", async (string username, string passwordUtente, string namePassword, string password, IManagerPassword ManagerP) =>
                {

                    return TypedResults.Ok(ManagerP.NewPassword(username, passwordUtente, namePassword, password));
                });
                app.MapGet("/api/get/password", async (string username, string passwordUtente, string namePassword, IManagerPassword ManagerP) =>
                {

                    return TypedResults.Ok(ManagerP.GetPassword(username, passwordUtente, namePassword));
                });
                app.MapGet("/api/get/all/password", async (string username, string passwordUtente, IManagerPassword ManagerP) =>
                {

                    return TypedResults.Ok(ManagerP.GetPassword(username, passwordUtente));
                });
                app.MapPut("/api/change/password", async (string username, string passwordUtente, string namePassword, string password, IManagerPassword ManagerP) =>
                {

                    return TypedResults.Ok(ManagerP.ChangePassword(username, passwordUtente, namePassword, password));
                });
                return app;
            }
    }
}