using PasswordGen.Service;
using PasswordGen.Model;
using System.Runtime.CompilerServices;

namespace PasswordGen
{

    public static class AppRouteExtensions
    {
        public static WebApplication AddEndPointUtente(this WebApplication app)
        {
            app.MapGet("/api/get/Utente}", async (string username, string password, string passwordName, IManagerDb db) =>
            {
                return TypedResults.Ok(db.getUtente(db.getId(username, password)));
            });
            app.MapPost("/api/new/Utente", async (string username, string password, IManagerDb db) =>
            {
                return TypedResults.Ok(db.newUtente(username, password));
            });
            return app;
        }
        public static WebApplication AddEndPointPassword(this WebApplication app)
        {
            app.MapGet("/api/get/Password/", async (string username, string password, IManagerDb db) =>
            {
                return TypedResults.Ok(db.getPassword(db.getId(username, password)));
            });
            app.MapGet("/api/get/Password/{passwordName}", async (string username, string password, string passwordName, IManagerDb db) =>
            {
                return TypedResults.Ok(db.getPassword(db.getId(username, password), passwordName));
            });
            app.MapPost("/api/new/Password", async (string username, string passwordUtente, string nomePassword, string password, IManagerDb db) =>
            {

                return TypedResults.Ok(db.newPassword(db.getId(username, passwordUtente), new Password { name = nomePassword, password = password }));
            });
            return app;
        }
    }
}