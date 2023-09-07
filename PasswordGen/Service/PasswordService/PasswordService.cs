using Nest;
using PasswordGen.Model;
using PasswordGen.Repository;
using PasswordGen.Service.PasswordService.GeneratorePassword.Builder.Factory;
using System.Reflection.Metadata.Ecma335;

namespace PasswordGen.Service.PasswordService
{
    public class PasswordService : IPasswordService
    {
        readonly IManagerDb Db;
        IFactory? Factory;
        public PasswordService(IManagerDb db, IFactory? factory)
        {
            Db = db;
            Factory = factory;
        }

        public async Task<bool> ChangePassword(int? idUtente, string nomePassword, string newPassword)
        {
           
            if(idUtente is null)return false;
            if (await Db.GetUtenteWithPassword(idUtente) is Utente u)
            {
                if (u.GetPassword(nomePassword)?.SetPassword(newPassword)??false)
                {
                    return await Db.Save();
                }
            }
            return false;
        }

        public async Task<bool> DeletePassword(int? idUtente, string nomePassword)
        {
            if (idUtente is null) return false;
            if ((await Db.GetUtenteWithPassword(idUtente))?.DeletePassword(nomePassword) is true)
                return await Db.Save();
            return false;
        }

        public async Task<PasswordModel?> GetPassword(int? idUtente, string nomePassword)
        {
            if (idUtente is null) return null;
            return (await Db.GetUtenteWithPassword(idUtente))?.GetPassword(nomePassword);
        }

        public async Task<List<PasswordModel>?> GetPassword(int? idUtente)
        {
            if (idUtente is null) return null;
            return (await Db.GetUtenteWithPassword(idUtente))?.PasswordList??null;
        }

        public async Task<bool> NewPassword(int? idUtente, string nomePassword, string password)
        {
            if (idUtente is null) return false;
            if ((await Db.GetUtenteWithPassword(idUtente))?.AddPassword(nomePassword, password) is true)
                     return await Db.Save();
            return false;
        }

        public async Task<string?> NewPassword(int? idUtente, string namePassword, FactoryBuilder.TypePassword type)
        {
            if (idUtente is null) return null;
            if (Factory?.Get(type) is string password)
               return (await NewPassword(idUtente, namePassword, password)) ? password : null;
            return null;
        }
    }
}
