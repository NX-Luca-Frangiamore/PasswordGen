using PasswordGen.Service;
using PasswordGen.Model;
namespace PasswordGen
{
    public class MinimalApi
    {
        private WebApplication app=null;
        private static MinimalApi state=null;
        private MinimalApi(WebApplication app)
        {
            this.app = app;
        }
        public static MinimalApi getInstant(WebApplication app)
        {
            if (state == null)
                state = new MinimalApi(app);
            return state;
        }
        public void ApiGet()
        {
           
            app.MapGet("/api/get/Password/", async (string username, string password, IManagerDb db) =>
            {
                return TypedResults.Ok(db.getPassword(db.getId(username,password)));
            });
            app.MapGet("/api/get/Password/{passwordName}", async (string username, string password,string passwordName, IManagerDb db) =>
            {
                return TypedResults.Ok(db.getPassword(db.getId(username, password), passwordName));
            });


        }
        public void ApiPost()
        {
            app.MapPost("/api/new/Utente", async (string username, string password, IManagerDb db) =>
            {
                return TypedResults.Ok(db.newUtente(username, password));
            });
            app.MapPost("/api/new/Password", async (string username, string passwordUtente, string nomePassword, string password, IManagerDb db) =>
            {

                return TypedResults.Ok(db.newPassword(db.getId(username, passwordUtente), new Password { name = nomePassword, password = password }));
            });
        }
      
        
    }
    }
