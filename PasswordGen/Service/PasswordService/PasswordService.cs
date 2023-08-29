using PasswordGen.Model;
using PasswordGen.Repository;

namespace PasswordGen.Service.PasswordService
{
    public class PasswordService : IPasswordService
    {
        readonly IManagerDb Db;
        public PasswordService(IManagerDb db)
        {
            Db = db;
        }

        public async Task<bool> ChangePassword(string username, string passwordUtente, string nomePassword, string newPassword)
        {
            if (await Db.GetUtenteWithPassword(username, passwordUtente) is Utente u)
            {
                if (u.GetPassword(nomePassword)?.SetPassword(newPassword)??false)
                {
                    return await Db.Save();
                }
            }
            return false;
        }

        public async Task<bool> DeletePassword(string username, string passwordUtente, string nomePassword)
        {
            if((await Db.GetUtenteWithPassword(username, passwordUtente))?.DeletePassword(nomePassword) is true)
                return await Db.Save();
            return false;
        }

        public async Task<PasswordModel?> GetPassword(string username, string passwordUtente, string nomePassword)
        {
            return (await Db.GetUtenteWithPassword(username, passwordUtente))?.GetPassword(nomePassword);
        }

        public async Task<List<PasswordModel>?> GetPassword(string username, string passwordUtente)
        {
            return (await Db.GetUtenteWithPassword(username, passwordUtente))?.PasswordList??null;
        }

        public async Task<bool> NewPassword(string username, string passwordUtente, string nomePassword, string password)
        {
            if((await Db.GetUtenteWithPassword(username, passwordUtente))?.AddPassword(nomePassword, password) is true)
                     return await Db.Save();
            return false;
        }
    }
}
