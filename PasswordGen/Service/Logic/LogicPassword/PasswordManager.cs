using PasswordGen.Service.Db;
using PasswordGen.Model;
using PasswordGen.Service.Logic.LogicPassword;

namespace PasswordGen.Data
{
    public class PasswordManager : IPasswordManager
    {
        readonly IManagerDb Db;
        public PasswordManager(IManagerDb db)
        {
            Db = db;
        }

        public async Task<bool> ChangePassword(string username, string passwordUtente, string nomePassword, string newPassword)
        {
            if (await Db.GetUtenteWithPassword(username, passwordUtente) is Utente u)
            {
                if (u.GetPassword(nomePassword) is PasswordModel p)
                {
                    p.SetPassword(newPassword);
                    return await Db.Save();
                }
            }
            return false;
        }

        public async Task<bool> DeletePassword(string username, string passwordUtente, string nomePassword)
        {
            if (await Db.GetUtenteWithPassword(username, passwordUtente) is Utente u)
            {
                u.DeletePassword(nomePassword);
                return await Db.Save();
            }
            return false;
        }

        public async Task<PasswordModel?> GetPassword(string username, string passwordUtente, string nomePassword)
        {
            var a = (await Db.GetUtenteWithPassword(username, passwordUtente));
            if (a is Utente u)
            {
                return u.GetPassword(nomePassword);
            }
            return null;
        }

        public async Task<List<PasswordModel>?> GetPassword(string username, string passwordUtente)
        {
            if (await Db.GetUtenteWithPassword(username, passwordUtente) is Utente u)
            {
                return u.PasswordList;
            }
            return null;
        }

        public async Task<bool> NewPassword(string username, string passwordUtente, string nomePassword, string password)
        {
            if ((await Db.GetUtenteWithPassword(username, passwordUtente)) is Utente u)
            {
                if (u.AddPassword(nomePassword, password))
                {
                    return await Db.Save();
                }

            }
            return false;
        }
    }
}
