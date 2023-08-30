using PasswordGen.Model;
using PasswordGen.Repository;
using PasswordGen.Service.PasswordService.GeneratorePassword.Builder.Factory;
using System.Reflection.Metadata.Ecma335;

namespace PasswordGen.Service.PasswordService
{
    public class PasswordService : IPasswordService
    {
        readonly IManagerDb Db;
        FactoryBuilder? Factory;
        public PasswordService(IManagerDb db, FactoryBuilder? factory)
        {
            Db = db;
            Factory = factory;
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

        public async Task<string?> NewPassword(string username, string passwordUtente, string namePassword, FactoryBuilder.TypePassword type)
        {
            if(Factory?.Get(type) is string password)
               return (await NewPassword(username, passwordUtente, namePassword, password)) ? password : null;
            return null;
        }
    }
}
