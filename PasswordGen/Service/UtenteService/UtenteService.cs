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
        public async Task<bool> NewUtente(string nome, string cognome)
        {
            if (Utente.Create(nome, cognome) is Utente u)
                return await Db.NewUtente(u);
            return false;

        }
        public async Task<bool> ChangeUtente(string username, string password, string usernameNew, string passwordNew)
        {
            if (await Db.GetUtente(username, password) is Utente u)
            {
                u.ChangeCredenziali(usernameNew, passwordNew);
                return await Db.Save();

            }
            return false;

        }

        public async Task<bool> DeleteUtente(string username, string password)
        {
            if (await Db.GetUtente(username, password) is not null)
            {
                await Db.DeleteUtente(username, password);
                return await Db.Save();
            }
            return false;
        }
        public async Task<Utente?> GetUtente(string username, string password)
        {
            if (await Db.GetUtente(username, password) is Utente u)
            {
                return u;
            }
            return null;
        }
    }
}
