using PasswordGen.Model;
using PasswordGen.Repository;
using PasswordGen.Service.PasswordService.GeneratorePassword.Factory;

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
            if (await Db.GetUtente(idUtente) is Utente u)
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
            if ((await Db.GetUtente(idUtente))?.DeletePassword(nomePassword) is true)
                return await Db.Save();
            return false;
        }

        public async Task<PasswordModel?> GetPassword(int? idUtente, string nomePassword)
        {
            if (idUtente is null) return null;
            return (await Db.GetUtente(idUtente))?.GetPassword(nomePassword);
        }

        public async Task<List<PasswordModel>?> GetPassword(int? idUtente)
        {
            if (idUtente is null) return null;
            return (await Db.GetUtente(idUtente))?.PasswordList??null;
        }

        public async Task<bool> NewPassword(int? idUtente, string nomePassword, string password)
        {
            if (idUtente is null) return false;
            if ((await Db.GetUtente(idUtente))?.AddPassword(nomePassword, password) is true)
                     return await Db.Save();
            return false;
        }

        public async Task<string?> NewPasswordRandom(int? idUtente, string namePassword, FactoryBuilder.TypePassword type)
        {
            if (idUtente is null) return null;
            if (Factory?.Get(type) is string password)
               return (await NewPassword(idUtente, namePassword, password)) ? password : null;
            return null;
        }
    }
}
