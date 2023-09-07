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
        public async Task<bool> NewUtente(string? username,string? password)
        {
            if (username is null || password is null) return false;
            if ((await Db.GetUtente(username, password)) is null)
                if (Utente.Create(username, password) is Utente u)
                    return await Db.NewUtente(u);

            return false;

        }
        public async Task<bool> ChangeUtente(int? idUtente, string? usernameNew, string? passwordNew)
        {
            if (idUtente is null) return false;
            if ((await Db.GetUtente(idUtente))?.ChangeCredenziali(usernameNew, passwordNew) is true)
                 return await Db.Save();
            return false;

        }

        public async Task<bool> DeleteUtente(int? idUtente)
        {
            if (idUtente is null) return false;
            return (await Db.DeleteUtente(idUtente));
        }
        public async Task<Utente?> GetUtente(int? idUtente)
        {
            if (idUtente is null) return null;
            return (await Db.GetUtente(idUtente));
        }
    }
}
