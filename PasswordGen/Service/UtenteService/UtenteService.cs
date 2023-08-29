using PasswordGen.Model;
using PasswordGen.Repository;

namespace PasswordGen.Service.UtenteService
{
    public class UtenteService : IUtenteService
    {
        readonly IManagerDb Db;
        public UtenteService(IManagerDb db)
        {
            Db = db;
        }
        public async Task<bool> NewUtente(string username, string password)
        {
            if ((await Db.GetUtente(username, password)) is null)
                if (Utente.Create(username, password) is Utente u)
                    return await Db.NewUtente(u);

            return false;

        }
        public async Task<bool> ChangeUtente(string username, string password, string? usernameNew, string? passwordNew)
        {
            if ((await Db.GetUtente(username, password))?.ChangeCredenziali(usernameNew, passwordNew) is true)
                 return await Db.Save();
            return false;

        }

        public async Task<bool> DeleteUtente(string username, string password)
        {
            return (await Db.DeleteUtente(username, password)) && await Db.Save();
        }
        public async Task<Utente?> GetUtente(string username, string password)
        {
            return (await Db.GetUtente(username, password));
        }
    }
}
